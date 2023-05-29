using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //moving platform

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moving platform")
        {
            this.transform.parent = collision.transform;
        }
      
    }
    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Moving platform")
        {
            this.transform.parent = null;
        } 
    }


}
