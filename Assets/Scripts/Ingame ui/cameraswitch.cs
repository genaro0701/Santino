using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraswitch : MonoBehaviour
{
     [SerializeField] private GameObject vcamMain;
   [SerializeField] private GameObject vcamFocus;
   

   private bool isOnView = false;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
      if(isOnView == true){
       vcamFocus.SetActive(true);
       vcamMain.SetActive(false);
      }else {
        vcamFocus.SetActive(false);
        vcamMain.SetActive(true);
      }
    }

   private void OnTriggerStay2D(Collider2D other) {
     if (other.gameObject.CompareTag("Player"))
    {
      Debug.Log("switch");
      isOnView = true;
    }

   }

   private void OnTriggerExit2D(Collider2D other) {
     if (other.gameObject.CompareTag("Player"))
    {
      
      isOnView = false;
    }
   }

   
    


}
