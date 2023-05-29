using UnityEngine;

public class BungisngisAttack : MonoBehaviour
{
    [SerializeField] private Stats m_Bungisngis;

    [SerializeField] private LayerMask attackMask;
    [SerializeField] private Vector3 m_AttackOffset;
    [SerializeField] private float m_AttackRange = 1f;

    private Transform m_Player;
    private bool isFlipped = false;

    [HideInInspector] public bool isPlayerDied = false, returnPos;
    [HideInInspector] public Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * m_AttackOffset.x;
        pos += transform.up * m_AttackOffset.y;

        Collider2D collInfo = Physics2D.OverlapCircle(pos, m_AttackRange, attackMask);
        if (collInfo != null)
        {
            float hp = collInfo.GetComponent<PlayerHealth>().SetDamage(m_Bungisngis.bungisngis.attackDamage);
            isPlayerDied = (hp <= 0) ? true : false;
        }
    }
    
    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * m_AttackOffset.x;
        pos += transform.up * m_AttackOffset.y;

        Collider2D collInfo = Physics2D.OverlapCircle(pos, m_AttackRange, attackMask);
        if (collInfo != null)
        {
            float hp = collInfo.GetComponent<PlayerHealth>().SetDamage(m_Bungisngis.bossBungisngis.enlargedAttackDamage);
            isPlayerDied = (hp <= 0) ? true : false;
        }
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > m_Player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < m_Player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x + m_AttackOffset.x, transform.position.y + m_AttackOffset.y), m_AttackRange);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")) returnPos = true;
    }
}
