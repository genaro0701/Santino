using DG.Tweening;
using TMPro;
using UnityEngine;

public class KapreHealth : MonoBehaviour
{
    [SerializeField] private Stats m_Stats;
    [SerializeField] private Animator m_Anim;
    [SerializeField] private Disolve m_DiedEffect;

    [SerializeField] private GameObject m_Barrier;

    private int m_Health;
    private bool isDied = false;

    private void Start()
    {
        Reset();
    }

    public void SetDamage(int damage)
    {
        if (!isDied)
        {
            m_Anim.SetTrigger("Hurt");
            m_Health -= damage;

            DamageEffect(damage);

            Managers.Instance.uiManager.EnemyHealth(m_Health, m_Stats.kapre.name);

            if (m_Health < 0)
            {
                isDied = true;
                m_Anim.SetBool("Died", true);
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                GetComponent<CapsuleCollider2D>().enabled = false;
                
                if (m_Barrier != null) m_Barrier.SetActive(false);

                StartCoroutine(m_DiedEffect.Disolved());

                DropReward();
            }
        }
    }

    private void DropReward()
    {
        int rnd = Random.Range(1, 11);
        PlayerPrefasManager.Instance.Binhi = rnd;
        Managers.Instance.uiManager.SetBinhi(rnd);

        GameObject obj = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));

        if (obj != null)
            obj.transform.position = gameObject.transform.position;
    }

    private void DamageEffect(int _damage)
    {
        GameObject damagetxt = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Damage);
        damagetxt.transform.position = gameObject.transform.position;
        damagetxt.GetComponentInChildren<TextMeshProUGUI>().text = "-" + _damage.ToString();
        damagetxt.transform.DOJump(new Vector2(damagetxt.transform.position.x, damagetxt.transform.position.y + 0.5f), 2, 1, 1).OnComplete(() =>
        {
            BasicObjectPooling.Instance.Queue(damagetxt, eObjectPoolType.Damage);
        });
    }

    public void Reset()
    {
        m_Health = m_Stats.kapre.health;
    }
}
