using UnityEngine;

public class BossBungisngisWalk : StateMachineBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float m_WalkDistance = 20f;

    private BungisngisAttack m_BungisngisAttack;

    private float m_Distance;
    private Transform m_Player;
    private Rigidbody2D m_RB;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_RB = animator.GetComponent<Rigidbody2D>();
        m_BungisngisAttack = animator.GetComponent<BungisngisAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Distance = Vector2.Distance(m_Player.position, m_RB.position);

        if (m_BungisngisAttack.returnPos)
        {
            Vector2 newPos = Vector2.MoveTowards(m_RB.position, m_BungisngisAttack.startPos, speed / 2);
            m_RB.MovePosition(newPos);

            if (animator.transform.position.x == m_BungisngisAttack.startPos.x)
            {
                animator.GetComponent<BossBungisngisHealth>().Reset();
                animator.SetTrigger("Idle");
                m_BungisngisAttack.returnPos = false;
            }
        }

        else if (m_Distance <= m_WalkDistance && !m_BungisngisAttack.isPlayerDied)
        {
            m_BungisngisAttack.LookAtPlayer();

            Vector2 target = new Vector2(m_Player.position.x, m_RB.position.y);
            Vector2 newPos = Vector2.MoveTowards(m_RB.position, target, speed * Time.deltaTime);
            m_RB.MovePosition(newPos);

            if (m_Distance <= attackRange)
                animator.SetTrigger("Attack");
        }

        else if (m_Distance >= m_WalkDistance || m_BungisngisAttack.isPlayerDied)
            animator.SetTrigger("Idle");

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Idle");
    }
}
