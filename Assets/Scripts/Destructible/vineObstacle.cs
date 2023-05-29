using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vineObstacle : MonoBehaviour
{
   [SerializeField] GameObject vineObject;
    [SerializeField] ParticleSystem effects;
   [SerializeField] private int vinehealth = 5;
    private bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDamage(int damage){
        if(!isBroken){
            vinehealth -= damage;
            effects.Play();

            if(vinehealth < 0){
                vineObject.SetActive(false);
                isBroken = true;

            }            
        }

    }

}
