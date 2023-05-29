using UnityEngine;

public class Tiyanak : MonoBehaviour
{
    [SerializeField] private GameObject m_WeaponReward;
    [SerializeField] private Vector2[] m_Position;

    private void Start()
    {
        transform.position = m_Position[Random.Range(0, 8)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefasManager.Instance.PlayerWeapon <= 2)
            {
                m_WeaponReward.transform.position = transform.position;
                m_WeaponReward.SetActive(true);
            }
            else
            {
                GameObject obj = BasicObjectPooling.Instance.Dequeue((eObjectPoolType)Random.Range(0, 4));
                obj.transform.position = gameObject.transform.position;
            }

            Destroy(gameObject);
            FindObjectOfType<ButtonManager>().Objective(0);
        }
    }
}
