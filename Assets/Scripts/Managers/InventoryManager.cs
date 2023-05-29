using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    [SerializeField] private RawMaterial m_Material;

    [SerializeField] private GameObject m_infoPanel;
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private Image m_materialIcon;
    [SerializeField] private TextMeshProUGUI m_info;

    [SerializeField] private Image[] m_MaterialContainer;
    [SerializeField] private TextMeshProUGUI[] m_Counttext;

    private bool empty = false;
    
    public void AddToInventory(int index, int count)
    {
        //forloop in the list of container
        for (int i = 0; i < m_MaterialContainer.Length; i++)
        {
            //Material is ALREADY on inventory
            if (m_MaterialContainer[i].sprite == m_Material.materials[index].icon)
            {
                //if YES add to the existing container
                m_Counttext[i].text = count.ToString();
                break;
            }
            else 
            //Material NOT ON inventory
            {
                Image image = m_MaterialContainer[i];
                TextMeshProUGUI text = m_Counttext[i];

                //check if the container is EMPTY
                if (image.sprite == null)
                {
                    //if YES get the sprite and asign it then set the value and enable it.
                    PlayerPrefasManager.Instance.InventoryContainer(m_MaterialContainer[i].name, index.ToString());
                    image.sprite = m_Material.materials[index].icon;
                    image.enabled = true;
                    text.text = count.ToString();
                    text.enabled = true;
                    break;
                }
            }
                
        }
    }

    //dapat kapag 0 nalang yung material sa container empty na dapat ulit.
    public void Inventory()
    {
        for (int i = 0; i < m_MaterialContainer.Length; i++)
        {
            if (m_MaterialContainer[i].sprite != null)
            {
                m_MaterialContainer[i].sprite = null;
                m_MaterialContainer[i].enabled = false;
                m_Counttext[i].text = null;
            }

            //check in the playerprefs if the container has content
            string indexString = PlayerPrefasManager.Instance.InventoryContainer(m_MaterialContainer[i].name);

            //if the container is NOT NULL
            if (!string.IsNullOrEmpty(indexString))
            {
                int index = int.Parse(indexString);

                //check if the content is Halamang Gamot or Langis then set the count to it.
                switch (index)
                {
                    case 0:
                        int niyog = PlayerPrefasManager.Instance.Niyog;
                        empty = (niyog == 0) ? true : false;
                        if (!empty) AddToInventory(0, niyog);
                        break;
                    case 1:
                        int ugat = PlayerPrefasManager.Instance.Ugat;
                        empty = (ugat == 0) ? true : false;
                        if (!empty) AddToInventory(1, ugat);
                        break;
                    case 2:
                        int baging = PlayerPrefasManager.Instance.Baging;
                        empty = (baging == 0) ? true : false;
                        if (!empty) AddToInventory(2, baging);
                        break;
                    case 3:
                        int tanso = PlayerPrefasManager.Instance.Tanso;
                        empty = (tanso == 0) ? true : false;
                        if (!empty) AddToInventory(3, tanso);
                        break;
                    case 4:
                        int langis = PlayerPrefasManager.Instance.Langis;
                        empty = (langis == 0) ? true : false;
                        if (!empty) AddToInventory(4, langis);
                        break;
                    case 5:
                        int agimat = PlayerPrefasManager.Instance.Agimat;
                        empty = (agimat == 0) ? true : false;
                        if (!empty) AddToInventory(5, agimat);
                        break;
                    case 6:
                        int page = PlayerPrefasManager.Instance.Page;
                        empty = (page == 0) ? true : false;
                        if (!empty) AddToInventory(6, page);
                        break;
                    //Cross
                    case 7:
                        int cross1 = PlayerPrefasManager.Instance.Cross(1);
                        empty = (cross1 == 0) ? true : false;
                        if (!empty) AddToInventory(7, 1);
                        break;
                    case 8:
                        int cross2 = PlayerPrefasManager.Instance.Cross(2);
                        empty = (cross2 == 0) ? true : false;
                        if (!empty) AddToInventory(8, 1);
                        break;
                    case 9:
                        int cross3 = PlayerPrefasManager.Instance.Cross(3);
                        empty = (cross3 == 0) ? true : false;
                        if (!empty) AddToInventory(9, 1);
                        break;
                    case 10:
                        int cross4 = PlayerPrefasManager.Instance.Cross(4);
                        empty = (cross4 == 0) ? true : false;
                        if (!empty) AddToInventory(10, 1);
                        break;
                    case 11:
                        int cross5 = PlayerPrefasManager.Instance.Cross(5);
                        empty = (cross5 == 0) ? true : false;
                        if (!empty) AddToInventory(11, 1);
                        break;
                }

                //O material
                if (empty)
                {
                    m_MaterialContainer[i].sprite = null;
                    m_MaterialContainer[i].enabled = false;
                    m_Counttext[i].text = "";
                    PlayerPrefs.DeleteKey(m_MaterialContainer[i].name);
                }
            }
        }
    }


    //Material Info
    public void MaterialInfo(int materialIndex)
    {
        m_Title.text = m_Material.materials[materialIndex].materialName;
        m_materialIcon.sprite = m_Material.materials[materialIndex].icon;
        m_info.text = m_Material.materials[materialIndex].info;
        m_infoPanel.SetActive(true);
    }
}
