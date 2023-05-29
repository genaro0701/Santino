using UnityEngine;

public class PlayerPrefasManager : Singleton<PlayerPrefasManager>
{
    #region Level

    //Get player level
    public int Level
    {
        get 
        { return PlayerPrefs.GetInt("Level"); }

        set
        {
            value += Level;
            PlayerPrefs.SetInt("Level", value);
        }

    }
   
    #endregion

    #region Material
    //SetBinhi Count
    public int Binhi
    {
        get { return PlayerPrefs.GetInt("Binhi"); }
        set
        {
            value += Binhi;
            PlayerPrefs.SetInt("Binhi", value);
        }
    }


    //Get langis quantity
    public int Langis
    {
        get { return PlayerPrefs.GetInt("Langis"); }
        set
        {
            value += Langis;
            PlayerPrefs.SetInt("Langis", value);
        }
    }

    //Set Halamang Gamot count then return count
    public int Niyog
    {
        get { return PlayerPrefs.GetInt("Niyog"); }
        set
        {
            value += Niyog;
            PlayerPrefs.SetInt("Niyog", value);
        }
    }

    //Set Langis count then return count
    public int Ugat
    {
        get { return PlayerPrefs.GetInt("Ugat"); }
        set
        {
            value += Ugat;
            PlayerPrefs.SetInt("Ugat", value);
        }
    }


    //Set Agimat count then return count
    public int Agimat
    {
        get { return PlayerPrefs.GetInt("Agimat"); }
        set
        {
            value += Agimat;
            PlayerPrefs.SetInt("Agimat", value);
        }
    }

    //Set baging count then return count
    public int Baging
    {
        get { return PlayerPrefs.GetInt("Baging"); }
        set
        {
            value += Baging;
            PlayerPrefs.SetInt("Baging", value);
        }
    }

    //Set Pilak count then return count
    public int Tanso
    {
        get { return PlayerPrefs.GetInt("Tanso"); }
        set
        {
            value += Tanso;
            PlayerPrefs.SetInt("Tanso", value);
        }
    }

    //Set BiblePage count then return quantity
    public int Page
    {
        get { return PlayerPrefs.GetInt("Page"); }
        set
        {
            value += Page;
            PlayerPrefs.SetInt("Page", value);
        }
    }

    public int Gulugod
    {
        get { return PlayerPrefs.GetInt("Gulugod"); }
        set 
        { 
            value += Gulugod;
            PlayerPrefs.SetInt("Gulugod", value);
        }
    }
    
    public int Salt
    {
        get { return PlayerPrefs.GetInt("Salt"); }
        set 
        { 
            value += Salt;
            PlayerPrefs.SetInt("Salt", value);
        }
    }

    public void Cross(string num)
    {
        PlayerPrefs.SetInt("Cross" + num, 1);
    }

    public int Cross(int num)
    {
        return PlayerPrefs.GetInt("Cross" + num);
    }

    #endregion

    #region Invetory
    //Set Inventory container content
    public void InventoryContainer(string ContainerName, string spriteIndex)
    {
        PlayerPrefs.SetString(ContainerName, spriteIndex);
    }
    
    //Get container content
    public string InventoryContainer(string ContainerName)
    {
       return PlayerPrefs.GetString(ContainerName);
    }
    #endregion

    #region Player

    public string PlayerName
    {
        get { return PlayerPrefs.GetString("PlayersName"); }
        set { PlayerPrefs.SetString("PlayersName", value); }
    }

    public int PlayerWeapon
    {
        get { return PlayerPrefs.GetInt("PlayerWeapon"); }
        set { PlayerPrefs.SetInt("PlayerWeapon", value); }
    }

    public int ChangeWeapon
    {
        get { return PlayerPrefs.GetInt("ChangeWeapon"); }
        set { PlayerPrefs.SetInt("ChangeWeapon", value); }
    }

    public float PlayerHealth
    {
        get { return PlayerPrefs.GetFloat("Health"); }
        set { PlayerPrefs.SetFloat("Health", value); }
    }

    //set postion x and y
    public float PositionX
    {
        get { return PlayerPrefs.GetFloat("PosX"); }
        set { PlayerPrefs.SetFloat("PosX", value); }
    }

    public float PositionY
    {
        get { return PlayerPrefs.GetFloat("PosY"); }
        set { PlayerPrefs.SetFloat("PosY", value); }
    }

    public int FrameSaved
    {
        get { return PlayerPrefs.GetInt("SavedFrame"); }
        set { PlayerPrefs.SetInt("SavedFrame", value); }
    }


    public int CurrentFrame
    {
        get { return PlayerPrefs.GetInt("CurrentFrame"); }
        set { PlayerPrefs.SetInt("CurrentFrame", value); }
    }
    #endregion

    #region settings
    public string Tutorial
    {
        get { return PlayerPrefs.GetString("Tutorial"); }
        set { PlayerPrefs.SetString("Tutorial", value); }
    }

    public int CutScene
    {
        get { return PlayerPrefs.GetInt("CutScene"); }
        set { PlayerPrefs.SetInt("CutScene", value); }
    }
    
    public float MasterVolume
    {
        get { return PlayerPrefs.GetFloat("MasterVolume"); }
        set { PlayerPrefs.SetFloat("MasterVolume", value); }
    }
    public float BGMVolume
    {
        get { return PlayerPrefs.GetFloat("BGMVolume"); }
        set { PlayerPrefs.SetFloat("BGMVolume", value); }
    }
    public float SFXVolume
    {
        get { return PlayerPrefs.GetFloat("SFXVolume"); }
        set { PlayerPrefs.SetFloat("SFXVolume", value); }
    }
    #endregion
}


