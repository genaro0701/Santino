using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructibleWall : MonoBehaviour
{
 
    [SerializeField] GameObject brokenWall;
    [SerializeField] GameObject wholeWall;
    [SerializeField] ParticleSystem effects;
   [SerializeField] private int health = 18;
    private bool isBroken = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetDamage(int damage){
        if(!isBroken){
            health -= damage;
            effects.Play();

            if(health < 0){
                brokenWall.SetActive(true);
                Managers.Instance.audioManager.Play("RockDestroy");
                wholeWall.SetActive(false);
                isBroken = true;

            }            
        }

    }


}
