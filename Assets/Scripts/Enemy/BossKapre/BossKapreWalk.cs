using UnityEngine;

public class BossKapreWalk : StateMachineBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float m_WalkDistance = 20f;

    private BossKapreAttack m_Attack;

    private float m_Distance;
    private Transform m_Player;
    private Rigidbody2D m_RB;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_RB = animator.GetComponent<Rigidbody2D>();
        m_Attack = animator.GetComponent<BossKapreAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Distance = Vector2.Distance(m_Player.position, m_RB.position);

        if (m_Attack.returnPos)
        {
                Vector2 newPos = Vector2.MoveTowards(m_RB.position, m_Attack.startPos, speed / 2);
                m_RB.MovePosition(newPos);

                if (animator.transform.position.x == m_Attack.startPos.x)
                {
                    if (animator.gameObject.CompareTag("Boss Kapre"))
                        animator.GetComponent<BossKapreHealth>().Reset();

                    else
                        animator.GetComponent<KapreHealth>().Reset();

                    animator.SetTrigger("Idle");
                    m_Attack.returnPos = false;
                }
        }

        else if (m_Distance <= m_WalkDistance && !m_Attack.isPlayerDied)
        {
            m_Attack.LookAtPlayer();

            Vector2 target = new Vector2(m_Player.position.x, m_RB.position.y);
            Vector2 newPos = Vector2.MoveTowards(m_RB.position, target, speed * Time.deltaTime);
            m_RB.MovePosition(newPos);

            if (m_Distance <= attackRange)
                animator.SetTrigger("Attack");
        }

        else if (m_Distance >= m_WalkDistance || m_Attack.isPlayerDied)
            animator.SetTrigger("Idle");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
