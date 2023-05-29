using UnityEngine;
using DG.Tweening;


public class infoTrigger : MonoBehaviour
{
  [SerializeField] private GameObject info;
  private bool isactive = false;

private void OnCollisionStay2D(Collision2D other) {
    if(other.collider.CompareTag("Player")){
       if(isactive == false){
        info.SetActive(true);
        isactive = true;
       }
        
    }

}

private void OnCollisionExit2D(Collision2D other) {
    if(other.collider.CompareTag("Player")){

       if(isactive == true){
        info.SetActive(false);
        isactive = false;
       }
    }

}

}
