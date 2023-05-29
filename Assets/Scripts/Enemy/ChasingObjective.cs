using UnityEngine;

public class ChasingObjective : MonoBehaviour
{
    [SerializeField] private GameObject m_Batibat;

    // Start is called before the first frame update
    void Start()
    {
        float distance = GameObject.FindGameObjectWithTag("Player").transform.localPosition.x;

        if (distance > transform.localPosition.x)
        {
            m_Batibat.transform.position = new (distance - 18f, m_Batibat.transform.position.y);
            m_Batibat.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_Batibat.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
