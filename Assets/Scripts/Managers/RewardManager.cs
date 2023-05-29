using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class RewardManager : MonoBehaviour
{

    [SerializeField] private GameObject[] m_Material;
    [SerializeField] private TextMeshProUGUI[] m_Text;
    [SerializeField] private int m_MaxRandomRange = 6;
    [SerializeField] private int m_CrossNum;

    private void OnEnable()
    {
        for (int i = 0; i < m_Material.Length; i++)
        {
            int rnd = Random.Range(1, m_MaxRandomRange);
            if (i < m_Material.Length - 1)
                m_Text[i].text = rnd.ToString();

            switch (i)
            {
                case 0:
                    PlayerPrefasManager.Instance.Baging = rnd;
                    break;
                case 1:
                    PlayerPrefasManager.Instance.Ugat = rnd;
                    break;
                case 2:
                    PlayerPrefasManager.Instance.Tanso = rnd;
                    break;
                case 3:
                    PlayerPrefasManager.Instance.Niyog = rnd;
                    break;
                case 4:
                    PlayerPrefasManager.Instance.Langis = rnd;
                    break;
                case 5:
                    PlayerPrefasManager.Instance.Agimat = rnd;
                    break;
                default:
                    PlayerPrefasManager.Instance.Cross(m_CrossNum.ToString());
                    Managers.Instance.inventoryManager.AddToInventory(6 + m_CrossNum, 1);
                    break;
            }
        }


        StartCoroutine(Item());
    }

    private IEnumerator Item()
    {
        foreach (var item in m_Material)
            item.transform.localScale = Vector3.zero;

        foreach (var item in m_Material)
        {
            item.transform.DOScale(1f, 1f).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }
}
