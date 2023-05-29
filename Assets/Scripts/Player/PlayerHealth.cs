using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private Stats m_SantinoStats;
    [SerializeField] private PlayerVFX m_damageEffect;

    private float m_HP;
    private int m_CurrentLevel, m_SavedLevel;

    private bool isDied = false;

    [HideInInspector] public bool isAgimatActive = false;

    public float SetHealth(float health = 0)
    {
        m_HP += health;

        if (health > 0)
        {
            //add health in worldspace
            GameObject obj = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Regine);
            obj.transform.position = gameObject.transform.position;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = "+" + health.ToString();
            obj.transform.DOJump(new Vector2(obj.transform.position.x, obj.transform.position.y + 0.5f), 2, 1, 1).OnComplete(() =>
            {
                BasicObjectPooling.Instance.Queue(obj, eObjectPoolType.Regine);
            });
        }

        if (m_HP > 100) m_HP = 100;
        if (m_CurrentLevel == m_SavedLevel) PlayerPrefasManager.Instance.PlayerHealth = m_HP;
        Managers.Instance.uiManager.PlayersHealth(m_HP);
        return m_HP;
    }

    public float SetDamage(float damage, bool _deadZone = false)
    {
        if (!isDied)
        {
            m_damageEffect.DamageVFX();
            PlayerAnimation.Instance.SantinoHurt();

            //Agimat is ACTIVE
            if (isAgimatActive && !_deadZone)
            {
                damage = Mathf.Round(damage * .25f);
                m_HP -= damage;
            }
            else
                m_HP -= damage;

            //Damage 
            GameObject obj = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Damage);
            obj.transform.position = gameObject.transform.position;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = "-" + damage.ToString();
            obj.transform.DOJump(new Vector2(obj.transform.position.x, obj.transform.position.y + 0.5f), 2, 1, 1).OnComplete(() =>
            {
                BasicObjectPooling.Instance.Queue(obj, eObjectPoolType.Damage);
            });

            Managers.Instance.uiManager.PlayersHealth(m_HP);
            if (m_CurrentLevel == m_SavedLevel) PlayerPrefasManager.Instance.PlayerHealth = m_HP;
        }

        if (m_HP <= 0)
        {
            isDied = true;
            PlayerAnimation.Instance.SantinoDie();
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Managers.Instance.uiManager.GameOver();
            PlayerPrefs.DeleteKey("PosX");
            PlayerPrefs.DeleteKey("PosY");
        }

        return m_HP;
    }



    public float LoadHealth(int _currentLevel, int _savedLevel)
    {
        float savedPlayerHealth = PlayerPrefasManager.Instance.PlayerHealth;
        m_CurrentLevel = _currentLevel;
        m_SavedLevel = _savedLevel;

        //Unang Play ng santino 100 health kahit mamatay siya sa level 1.1
        if (m_SavedLevel == 1 && savedPlayerHealth == 0)
            m_HP = m_SantinoStats.santino.health;

        //May saved Health
        else if (m_CurrentLevel == m_SavedLevel && savedPlayerHealth > 0)
            m_HP = savedPlayerHealth;

        //bumalik siya sa tapos niya na level 100 buhay niya
        else if (m_CurrentLevel != m_SavedLevel && PlayerPrefasManager.Instance.CurrentFrame == 0)
            m_HP = m_SantinoStats.santino.health;

        //kapag namatay
        else
            m_HP = 30;

        Managers.Instance.uiManager.PlayersHealth(m_HP);
        return savedPlayerHealth;
    }
}
