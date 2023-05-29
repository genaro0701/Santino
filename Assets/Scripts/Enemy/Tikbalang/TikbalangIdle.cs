using UnityEngine;

public class TikbalangIdle : StateMachineBehaviour
{
    [SerializeField] private float m_Distance = 20f;

    private Transform m_Player;
    private Tikbalang m_Tikbalang;
    private Rigidbody2D m_Rb;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Rb = animator.GetComponent<Rigidbody2D>();
        m_Tikbalang = animator.GetComponent<Tikbalang>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float distance = Vector2.Distance(m_Player.position, m_Rb.position);

        if (distance < m_Distance)
        {
            m_Tikbalang.LookAt();
            m_Tikbalang.Run();
            animator.SetTrigger("Run");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }
}
