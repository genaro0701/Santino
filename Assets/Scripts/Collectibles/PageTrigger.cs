using UnityEngine;

public class PageTrigger : MonoBehaviour
{
    [SerializeField] private GameObject m_WhiteLady;
    [SerializeField] private GameObject m_Barrier;

    private void Start()
    {
        int page = PlayerPrefasManager.Instance.Page;
        if (page > 0)
        {
            m_WhiteLady.SetActive(true);
            m_Barrier.SetActive(false);
            Page();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefasManager.Instance.Page = 1;
            Managers.Instance.inventoryManager.AddToInventory(6, PlayerPrefasManager.Instance.Page);
            m_WhiteLady.SetActive(true);
            m_Barrier.SetActive(false);
            Page();
        }
    }

    private void Page()
    {
        BasicObjectPooling.Instance.Queue(gameObject, eObjectPoolType.Page);
        Managers.Instance.uiManager.Page();
    }
}
