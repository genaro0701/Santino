using UnityEngine;

public class BungisngisIdle : StateMachineBehaviour
{
    private Transform m_Player;
    private Transform m_Bungisngis;
    private BungisngisAttack m_BungisngisAttack;
    [SerializeField] private float m_WalkDistance = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Bungisngis = animator.GetComponent<Transform>();
        m_BungisngisAttack = animator.GetComponent<BungisngisAttack>();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(m_Player.position, m_Bungisngis.position) <= m_WalkDistance + m_WalkDistance * 0.5f)
            Managers.Instance.audioManager.Play("BungisngisIdle");
        if (Vector2.Distance(m_Player.position, m_Bungisngis.position) <= m_WalkDistance + m_WalkDistance * 0.25f)
            Managers.Instance.audioManager.Play("BungisngisHalakhak");
        if (Vector2.Distance(m_Player.position, m_Bungisngis.position) <= m_WalkDistance && !m_BungisngisAttack.isPlayerDied)
            animator.SetTrigger("Walk");
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Walk");
    }
}
