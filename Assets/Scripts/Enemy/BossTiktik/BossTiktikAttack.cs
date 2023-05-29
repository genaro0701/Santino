using UnityEngine;

public class BossTiktikAttack : MonoBehaviour
{
    [SerializeField] private Stats m_TiktikStats;

    [SerializeField] private LayerMask attackMask;
    [SerializeField] private Vector3 m_AttackOffset;
    [SerializeField] private float m_AttackRange = 2f;

    private Transform m_Player;
    private bool isFlipped = false;

    [HideInInspector] public bool isPlayerDied = false, returnPosition = false;

    private void Start()
    {
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
            float hp = collInfo.GetComponent<PlayerHealth>().SetDamage(m_TiktikStats.bossTiktik.attackDamage);
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

    private void Return()
    {
        int rnd = Random.Range(0, 2);
        if (rnd == 1)
            returnPosition = true;
    }
}
