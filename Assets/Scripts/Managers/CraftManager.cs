using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private RawMaterial m_Material;
    [SerializeField] private TextMeshProUGUI m_Title, m_QuantityMaterial01, m_QuantityMaterial02;
    [SerializeField] private Image m_CraftIcon, m_CraftMaterial01, m_CraftMaterial02;

    private int m_Materialindex;
    private int langisQuantity, agimatQuantity;

    private void Start()
    {
        langisQuantity = m_Material.materials[4].craftQuantity;
        agimatQuantity = m_Material.materials[5].craftQuantity;
    }

    public void CraftMaterial(int index)
    {
        m_Materialindex = index;
        //Set Ui to this material
        m_Title.text = m_Material.materials[m_Materialindex].materialName;
        m_CraftIcon.sprite = m_Material.materials[m_Materialindex].icon;

        switch (m_Materialindex)
        {
            //Fill the UI NEEDED to craft LANGIS
            case 4:
                int niyog = PlayerPrefasManager.Instance.Niyog;
                int ugat = PlayerPrefasManager.Instance.Ugat;
                RawMaterial(0, niyog + "/" + langisQuantity, 1, ugat + "/" + langisQuantity);
                break;
            //Fill the UI NEEDED to craft AGIMAT
            case 5:
                int baging = PlayerPrefasManager.Instance.Baging;
                int tanso = PlayerPrefasManager.Instance.Tanso;
                RawMaterial(2, baging + "/" + agimatQuantity, 3, tanso + "/" + agimatQuantity);
                break;
        }

    }

    public void Craft()
    {
        switch (m_Materialindex)
        {
            //Langis
            case 4:
                int niyog = PlayerPrefasManager.Instance.Niyog;
                int ugat = PlayerPrefasManager.Instance.Ugat;
                
                if (niyog >= langisQuantity && ugat >= langisQuantity)
                {
                    PlayerPrefasManager.Instance.Niyog = -langisQuantity;
                    PlayerPrefasManager.Instance.Ugat = -langisQuantity;
                    PlayerPrefasManager.Instance.Langis = 1;
                    Managers.Instance.inventoryManager.AddToInventory(4, PlayerPrefasManager.Instance.Langis);
                    Managers.Instance.uiManager.Langis();
                    MessageSuccess();
                }
                else
                    MessageAlert();
                break;
            //Agimat
            case 5:
                int tanso = PlayerPrefasManager.Instance.Tanso;
                int baging = PlayerPrefasManager.Instance.Baging;

                if (tanso >= agimatQuantity && baging >= agimatQuantity)
                {
                    PlayerPrefasManager.Instance.Tanso = -agimatQuantity;
                    PlayerPrefasManager.Instance.Baging = -agimatQuantity;
                    PlayerPrefasManager.Instance.Agimat = 1;
                    Managers.Instance.inventoryManager.AddToInventory(5, PlayerPrefasManager.Instance.Agimat);
                    Managers.Instance.uiManager.Agimat();
                    MessageSuccess();
                }
                else
                    MessageAlert();
                break;
        }

        CraftMaterial(m_Materialindex);
        Managers.Instance.inventoryManager.Inventory();
    }

    public void RawMaterial(int _material01, string _quantity01, int _material02, string _quantity02)
    {
        m_CraftMaterial01.sprite = m_Material.materials[_material01].icon;
        m_QuantityMaterial01.text = _quantity01;
        m_CraftMaterial02.sprite = m_Material.materials[_material02].icon;
        m_QuantityMaterial02.text = _quantity02;
    }

    public void MessageSuccess()
    {
       StartCoroutine(Managers.Instance.uiManager.Message("You Successfully craft material. The material is send to your bag!"));
    }

    public void MessageAlert()
    {
       StartCoroutine(Managers.Instance.uiManager.Message("You Do Not Have Enough Material!"));
    }
}
