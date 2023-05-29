using UnityEngine;

public class BatibatIdle : StateMachineBehaviour
{
    [SerializeField] private float m_Distance = 20f;

    private Transform m_Player;
    private Rigidbody2D m_Rb;
    private BatibatAttack m_Batibat;
    private Trigger m_FinishLine;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rb = animator.GetComponent<Rigidbody2D>();
        m_Batibat = animator.GetComponent<BatibatAttack>();
        m_FinishLine = GameObject.FindGameObjectWithTag("Complete").GetComponent<Trigger>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(m_Player.position, m_Rb.position);

        if (distance < m_Distance && !m_Batibat.isPlayerDied && !m_FinishLine.isLevelComplete)
            animator.SetTrigger("Run");
        else
            animator.SetTrigger("Idle");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Idle");
    }
}
