using UnityEngine;

public class Nuno : StateMachineBehaviour
{
    private Transform m_Player;
    private Transform m_Nuno;
    private NunoAttack m_NunoAttack;
    [SerializeField] private float m_WalkDistance = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Nuno = animator.GetComponent<Transform>();
        m_NunoAttack = animator.GetComponent<NunoAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_NunoAttack.LookAtPlayer();

        if (Vector2.Distance(m_Player.position, m_Nuno.position) <= m_WalkDistance && m_Nuno.position.y <= m_Player.position.y && m_Player.position.y - m_Nuno.position.y <= 4f)
            animator.SetTrigger("Attack");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
