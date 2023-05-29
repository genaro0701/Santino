using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private RawMaterial m_AlbularyoPrice;


    public void Langis()
    {

    }

    public void Niyog()
    {
        int niyogPrice = m_AlbularyoPrice.materials[0].price;
        if(Binhi >= niyogPrice)
        {
            Play("Button");
            Binhi = -niyogPrice;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Niyog = 1;
            Managers.Instance.inventoryManager.AddToInventory(0, PlayerPrefasManager.Instance.Niyog);
        }

    }

    public void Ugat()
    {
        int ugatPrice = m_AlbularyoPrice.materials[1].price;
        if (Binhi >= ugatPrice)
        {
            Play("Button");
            Binhi = -ugatPrice;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Ugat = 1;
            Managers.Instance.inventoryManager.AddToInventory(1, PlayerPrefasManager.Instance.Ugat);
        }
    }

    public void Baging()
    {
        int bagingPrice = m_AlbularyoPrice.materials[2].price;
        if (Binhi >= bagingPrice)
        {
            Play("Button");
            Binhi = -bagingPrice;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Baging = 1;
            Managers.Instance.inventoryManager.AddToInventory(2, PlayerPrefasManager.Instance.Baging);
        }
    }

    public void Tanso()
    {
        int tansoPrice = m_AlbularyoPrice.materials[3].price;
        if (Binhi >= tansoPrice)
        {
            Play("Button");
            Binhi = -tansoPrice;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Tanso = 1;
            Managers.Instance.inventoryManager.AddToInventory(3, PlayerPrefasManager.Instance.Tanso);
        }
    }
    
    public void Gulogod()
    {
        int gulugod = m_AlbularyoPrice.materials[16].price;
        if (Binhi >= gulugod)
        {
            Play("Button");
            Binhi = -gulugod;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Gulugod = 1;
            Managers.Instance.inventoryManager.AddToInventory(16, PlayerPrefasManager.Instance.Gulugod);
        }
    }
    
    public void Salt()
    {
        int salt = m_AlbularyoPrice.materials[19].price;
        if (Binhi >= salt)
        {
            Play("Button");
            Binhi = -salt;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.Salt = 1;
            Managers.Instance.inventoryManager.AddToInventory(19, PlayerPrefasManager.Instance.Salt);
        }
    }

    public void Batuta()
    {
        int batuta = m_AlbularyoPrice.materials[20].price;
        if (Binhi >= batuta && PlayerPrefasManager.Instance.PlayerWeapon <= 3)
        {
            Play("Button");
            Binhi = -batuta;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.PlayerWeapon = 4;
            PlayerPrefasManager.Instance.ChangeWeapon = 4;
        }
        else
        {
            Managers.Instance.uiManager.Message("You Already Have It!!");
        }
    }
    
    public void Bat()
    {
        int bat = m_AlbularyoPrice.materials[21].price;
        if (Binhi >= bat && PlayerPrefasManager.Instance.PlayerWeapon <= 4)
        {
            Play("Button");
            Binhi = -bat;
            Managers.Instance.uiManager.BinhiOnload();
            PlayerPrefasManager.Instance.PlayerWeapon = 5;
            PlayerPrefasManager.Instance.ChangeWeapon = 5;
        }
        else
        {
            Managers.Instance.uiManager.Message("You Already Have It!!");
        }
    }

    private int Binhi
    {
       get { return PlayerPrefasManager.Instance.Binhi; }
       set { PlayerPrefasManager.Instance.Binhi = value; }
       
    }

    private void Play(string name)
    {
        Managers.Instance.audioManager.Play(name);
    }
}
