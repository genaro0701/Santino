using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateanim : MonoBehaviour
{
    [SerializeField] private GameObject anim;
    private void Start() {
        anim.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        Debug.Log("active");
         anim.SetActive(true);
    }
}
}
