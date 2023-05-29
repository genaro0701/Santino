using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{
    [SerializeField] private int nextFrame;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Managers.Instance.transitionManager.SetFrame(nextFrame);
        }
    }
   
}
