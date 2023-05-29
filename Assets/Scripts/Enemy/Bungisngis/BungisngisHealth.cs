using DG.Tweening;
using TMPro;
using UnityEngine;

public class BungisngisHealth : MonoBehaviour
{
    [SerializeField] private Stats m_Stats;
    [SerializeField] private Animator m_Anim;

    [SerializeField] private GameObject m_Barrier;

    [SerializeField] private ParticleSystem m_DamageEffect;
    [SerializeField] private Disolve m_DiedEffect;

    private int m_Health;
    private bool isDied = false;

    private void Start()
    {
        ReturnReset();
    }

    public void SetDamage(int damage)
    {
        if (!isDied)
        { 
            m_Anim.SetTrigger("Hurt");

            m_Health -= damage;
            Managers.Instance.uiManager.EnemyHealth(m_Health, m_Stats.bungisngis.name);

            DamageEffect(damage);

            if (m_Health < 0)
            {
                isDied = true;
                m_Anim.SetBool("Died", isDied);
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                GetComponent<CapsuleCollider2D>().enabled = false;

                if(m_Barrier != null)
                    m_Barrier.SetActive(false);

                StartCoroutine(m_DiedEffect.Disolved());

                DropReward();
            }
        }
       
    }

    private void DropReward()
    {
        GameObject obj = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));
        obj.transform.position = gameObject.transform.position;
        int rnd = Random.Range(1, 11);
        PlayerPrefasManager.Instance.Binhi = rnd;
        Managers.Instance.uiManager.SetBinhi(rnd);
    }

    private void DamageEffect(int _damage)
    {
        m_DamageEffect.Play();
        GameObject damagetxt = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Damage);
        damagetxt.transform.position = gameObject.transform.position;
        damagetxt.GetComponentInChildren<TextMeshProUGUI>().text = "-" + _damage.ToString();
        damagetxt.transform.DOJump(new Vector2(damagetxt.transform.position.x, damagetxt.transform.position.y + 0.5f), 2, 1, 1).OnComplete(() =>
        {
            BasicObjectPooling.Instance.Queue(damagetxt, eObjectPoolType.Damage);
        });
    }

    public void ReturnReset()
    {
        m_Health = m_Stats.bungisngis.health;
    }
}
