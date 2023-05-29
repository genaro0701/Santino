using UnityEngine;

public class BossTiktik : StateMachineBehaviour
{
    private Transform m_Player;
    private BossTiktikAttack m_Attack;
    private Rigidbody2D m_RB;
    private Vector2 m_BeforeAttackPos;
    private float m_Distance;

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float m_WalkDistance = 20f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_RB = animator.GetComponent<Rigidbody2D>();
        m_Attack = animator.GetComponent<BossTiktikAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Attack.LookAtPlayer();
        m_Distance = Vector2.Distance(m_Player.position, m_RB.position);

        if (m_Distance <= m_WalkDistance && !m_Attack.isPlayerDied && !m_Attack.returnPosition)
        {
            if (m_BeforeAttackPos == Vector2.zero)
                m_BeforeAttackPos = m_RB.position;

            Vector2 newPos = Vector2.MoveTowards(m_RB.position, m_Player.position, speed * Time.deltaTime);
            m_RB.MovePosition(newPos);

            if (m_Distance <= attackRange)
                animator.SetTrigger("Attack");
        }

        if (m_Attack.returnPosition)
        {
            Vector2 newPos = Vector2.MoveTowards(m_RB.position, m_BeforeAttackPos, speed * Time.deltaTime);
            m_RB.MovePosition(newPos);

            if (m_RB.position == m_BeforeAttackPos)
            {
                m_BeforeAttackPos = Vector2.zero;
                m_Attack.returnPosition = false;
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
