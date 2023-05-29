using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionDone : MonoBehaviour
{
    [SerializeField] GameObject  blackage;
    [SerializeField] GameObject  enable;  
    
     private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Missoin done!");
             Debug.Log("Something Happen!");
            blackage.SetActive(false);
            enable.SetActive(true);
            



        } 
    }
}
