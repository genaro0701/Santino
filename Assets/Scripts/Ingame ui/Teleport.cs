using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform distanation;
    public bool isFirstPortal;
    public float distance = 0.2f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = distanation.position;
        }
    }

}
