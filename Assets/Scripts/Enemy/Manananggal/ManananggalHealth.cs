using DG.Tweening;
using TMPro;
using UnityEngine;

public class ManananggalHealth : MonoBehaviour
{
    [SerializeField] private Stats m_Stats;
    [SerializeField] private Animator m_Anim;
    [SerializeField] private Disolve m_DiedEffect;

    private int m_Health;
    private bool isDied = false;

    private void Start()
    {
        m_Health = m_Stats.manananggal.health;
    }

    public void SetDamage(int damage)
    {
        if (!isDied)
        {
            m_Anim.SetTrigger("Hurt");
            m_Health -= damage;

            DamageEffect(damage);

            Managers.Instance.uiManager.EnemyHealth(m_Health, m_Stats.manananggal.name);

            if (m_Health < 0)
            {
                isDied = true;
                transform.position = new(transform.position.x, transform.position.y + 7);
                m_Anim.SetBool("Died", true);
                GetComponent<CircleCollider2D>().enabled = false;
                
                Managers.Instance.uiManager.LevelCompletePortal();

                StartCoroutine(m_DiedEffect.Disolved());

                DropReward();
            }
        }
    }

    private void DropReward()
    {
        int rnd = Random.Range(1, 5);
        PlayerPrefasManager.Instance.Binhi = rnd;
        Managers.Instance.uiManager.SetBinhi(rnd);

        GameObject obj = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));
        obj.transform.position = gameObject.transform.position;

        FindObjectOfType<ButtonManager>().Objective(0);
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
}
