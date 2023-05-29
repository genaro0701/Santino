using UnityEngine;

public class BossKapreIdle : StateMachineBehaviour
{
    private Transform m_Player;
    private Transform m_Kapre;
    private BossKapreAttack m_Attack;
    [SerializeField] private float m_WalkDistance = 20f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Kapre = animator.GetComponent<Transform>();   
        m_Attack = animator.GetComponent<BossKapreAttack>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(m_Player.position, m_Kapre.position) <= m_WalkDistance && !m_Attack.isPlayerDied)
        {
            Managers.Instance.audioManager.Play("KapreHalakhak");
            animator.SetTrigger("Run");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Run");
    }
}
