using DG.Tweening;
using UnityEngine;

public class ManananggalTorso : MonoBehaviour
{
    [SerializeField] private GameObject m_SaltButton;
    [SerializeField] private GameObject m_Manananggal;
    [SerializeField] private RectTransform m_Button;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_Button.DOScale(1.1f, .5f).OnComplete(() => m_Button.DORestart());
            m_SaltButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_SaltButton.SetActive(false);
        }
    }

    public void OnClick()
    {
        if (PlayerPrefasManager.Instance.Salt > 0)
        {
            PlayerPrefasManager.Instance.Salt = -1;
            gameObject.SetActive(false);
            m_Manananggal.SetActive(true);
        }

        else
        {
            StartCoroutine(Managers.Instance.uiManager.Message("You Don't Have Enough Salt!. Buy to Albularyo!"));
        }

    }
}
