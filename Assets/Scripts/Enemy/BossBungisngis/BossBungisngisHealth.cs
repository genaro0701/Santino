using DG.Tweening;
using TMPro;
using UnityEngine;

public class BossBungisngisHealth : MonoBehaviour
{
    [SerializeField] private Stats m_Stats;
    [SerializeField] private Animator m_Anim;
    
    [SerializeField] GameObject m_WeaponReward;
    [SerializeField] private Disolve m_DiedEffect;

    private int m_Health;

    private bool m_Rage = false, m_Enlarged = false, isDied = false;

    private void Start()
    {
        m_Health = m_Stats.bossBungisngis.health;
    }

    public void SetDamage(int damage)
    {
        if (!isDied && !m_Rage)
        {
            //m_Anim.SetTrigger("Hurt");
            m_Health -= damage;

            Managers.Instance.uiManager.EnemyHealth(m_Health, m_Stats.bossBungisngis.name);

            DamageEffect(damage);

            if (m_Health <= m_Stats.bossBungisngis.health / 2 && !m_Enlarged)
            {
                m_Enlarged = true;
                m_Rage = true;
                m_Anim.SetTrigger("Enlarge");
            }

            if (m_Health <= 0)
            {
                isDied = true;
                m_Anim.SetBool("Died", true);
                Managers.Instance.uiManager.LevelCompletePortal();
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                GetComponent<CapsuleCollider2D>().enabled = false;
                
                StartCoroutine(m_DiedEffect.Disolved());

                DropReward();
            }
        }
    }

    private void OnEnraged()
    {
        m_Rage = false;
        m_Anim.ResetTrigger("Enlarge");
    }

    private void DropReward()
    {
        int rnd = Random.Range(1, 11);
        PlayerPrefasManager.Instance.Binhi = rnd;
        Managers.Instance.uiManager.SetBinhi(rnd);

        if (PlayerPrefasManager.Instance.PlayerWeapon == 1)
        {
            m_WeaponReward.transform.position = transform.position;
            m_WeaponReward.SetActive(true);
        }
        else
        {
            GameObject obj = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));
            obj.transform.position = gameObject.transform.position;
        }

        FindObjectOfType<ButtonManager>().Objective(0);
    }

    private void DamageEffect(int damage)
    {
        GameObject obj = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Damage);
        obj.transform.position = gameObject.transform.position;
        obj.GetComponentInChildren<TextMeshProUGUI>().text = "-" + damage.ToString();
        obj.transform.DOJump(new Vector2(obj.transform.position.x, obj.transform.position.y + 0.5f), 2, 1, 1).OnComplete(() =>
        {
            BasicObjectPooling.Instance.Queue(obj, eObjectPoolType.Damage);
        });
    }

    public void Reset()
    {
        m_Health = m_Stats.bossBungisngis.health;
        m_Rage = false;
        m_Enlarged = false;
    }
}
