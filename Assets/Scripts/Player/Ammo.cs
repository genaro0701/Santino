using System.Collections;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private Stats m_Stats;
    [SerializeField] private float m_Speed = 20f;
    [SerializeField] private Rigidbody2D m_Rb;

    [SerializeField] private ParticleSystem m_Explosion;

    public void AttackNormal(Vector3 _transform)
    {
        m_Rb.velocity = _transform * m_Speed;

        StartCoroutine(Queue());
    }

    public void AttackMid(Vector3 _transform)
    {
        m_Rb.velocity = new Vector2(_transform.x, 0.1f) * m_Speed;

        StartCoroutine(Queue());
    }
    
    public void AttackHigh(Vector3 _transform)
    {
        m_Rb.velocity = new Vector2(_transform.x, 0.2f) * m_Speed;

        StartCoroutine(Queue());
    }

    private IEnumerator Queue()
    {
        yield return new WaitForSeconds(1.2f);
        BasicObjectPooling.Instance.Queue(gameObject, eObjectPoolType.Bawang);
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        int damage = m_Stats.santino.weapon[5].attackDamage;

        if (enemy.CompareTag("Bungisngis"))
        {
            Explosion();
            enemy.GetComponent<BungisngisHealth>().SetDamage(damage);
        }
        else if (enemy.CompareTag("Boss Bungisngis"))
        {
            Explosion();
            enemy.GetComponent<BossBungisngisHealth>().SetDamage((int)(damage + (damage * .20f)));
        }
        else if (enemy.CompareTag("Kapre"))
        {
            Explosion();
            enemy.GetComponent<KapreHealth>().SetDamage((int)(damage));
        }
        else if (enemy.CompareTag("Boss Kapre"))
        {
            Explosion();
            enemy.GetComponent<BossKapreHealth>().SetDamage((int)(damage + (damage * .23f)));
        }
        else if (enemy.CompareTag("Mob"))
        {
            Explosion();
            enemy.GetComponent<MobHealth>().SetDamage(damage);
        }
        else if (enemy.CompareTag("Boss Tiktik"))
        {
            Explosion();
            enemy.GetComponent<BossTiktikHealth>().SetDamage((int)(damage + (damage * .26f)));
        }
        else if (enemy.CompareTag("Manananggal"))
        {
            Explosion();
            enemy.GetComponent<ManananggalHealth>().SetDamage((int)(damage + (damage * .29f)));
        }
        else if (enemy.CompareTag("Destructible"))
        {
            Explosion();
            enemy.GetComponent<destructibleWall>().SetDamage(damage);
        }
        else if (enemy.CompareTag("DestructibleVine"))
        {
            Explosion();
            enemy.GetComponent<vineObstacle>().SetDamage(damage);
        }
    }

    private void Explosion()
    {
        GameObject obj = BasicObjectPooling.Instance.Dequeue(eObjectPoolType.Explosion);
        if (obj != null)
        {
            obj.transform.position = transform.position;
            BasicObjectPooling.Instance.Queue(gameObject, eObjectPoolType.Bawang);
        }
    }


}
