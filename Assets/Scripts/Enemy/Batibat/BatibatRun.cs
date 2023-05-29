using UnityEngine;

public class BatibatRun : StateMachineBehaviour
{
    [SerializeField] private float speed = 5f;

    private BatibatAttack m_Attack;
    private Transform m_Player;
    private Rigidbody2D m_RB;
    private Trigger m_FinishLine;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_RB = animator.GetComponent<Rigidbody2D>();
        m_Attack = animator.GetComponent<BatibatAttack>();
        m_FinishLine = GameObject.FindGameObjectWithTag("Complete").GetComponent<Trigger>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!m_Attack.isPlayerDied && !m_FinishLine.isLevelComplete)
        {
            Vector2 target = new Vector2(m_Player.position.x, m_RB.position.y);
            Vector2 newPos = Vector2.MoveTowards(m_RB.position, target, speed * Time.deltaTime);
            m_RB.MovePosition(newPos);
        }
        else
            animator.SetTrigger("Idle");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}
