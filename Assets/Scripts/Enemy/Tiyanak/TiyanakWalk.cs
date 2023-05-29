using UnityEngine;

public class TiyanakWalk : StateMachineBehaviour
{
    private Transform m_Player;
    private Transform m_Tiyanak;
    [SerializeField] private float m_WalkDistance = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
        m_Tiyanak = animator.GetComponent<Transform>();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(m_Player.position, m_Tiyanak.position) <= m_WalkDistance)
            Managers.Instance.audioManager.Play("TiyanakIyak");
    }
}
