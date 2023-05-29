using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [HideInInspector] public bool attack = false;
    [HideInInspector] public bool skill = false;
    [HideInInspector] public bool ultimate = false;

    private float m_TimetoAgimat = 0;

    public void LevelSelected(int level)
    {
        if (PlayerPrefasManager.Instance.Level >= level)
        {
            Play("Button");
            Managers.Instance.levelLoader.LoadLevel(level);
            DeleteKey("CurrentFrame");
        }
    }
    
    public void Next()
    {
        Play("Button");
        DeleteKey("PosX");
        DeleteKey("PosY");
        DeleteKey("SavedFrame");
        DeleteKey("CurrentFrame");
        DeleteKey("Cutscene");
    }

    public void OnQuit()
    {
        Play("Button");
        Application.Quit();
    }

    public void Jump()
    {
        PlayerMovement.Instance.jump = true;   
    }

    public void OnRetry()
    {
        Play("Button");
        Invoke(nameof(InvokeRetry), 0.3f);
    }

    private void InvokeRetry()
    {
        Managers.Instance.levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void SantinoChangeWeapon(int _weaponIndex)
    {
        if (_weaponIndex <= PlayerPrefasManager.Instance.PlayerWeapon && PlayerPrefasManager.Instance.ChangeWeapon != _weaponIndex)
            PlayerAnimation.Instance.SantinoChangeWeapon(_weaponIndex);
    }

    public void OnAttack()
    {
        attack = true;
    }

    public void OnSkill()
    {
        skill = true;
    }

    public void OnUltimate()
    {
        ultimate = true;
    }

    public void OnLangis()
    {

        //check kung may langis ka nga ba talaga.
        int langis = PlayerPrefasManager.Instance.Langis;

        if (langis > 0)
        {
            //get player health
            float hp = PlayerHealth.Instance.SetHealth();

            //if player health is NOT MAX
            if ((hp % 10) > 0 || (hp / 10) > 1 && (hp / 10) != 10 && hp != 0)
            {
                Play("Material");
                PlayerHealth.Instance.SetHealth(10);
                PlayerPrefasManager.Instance.Langis = -1;
                Managers.Instance.uiManager.Langis();
            }
        }
    }

    public void OnAgimat()
    {
        if(PlayerPrefasManager.Instance.Agimat > 0 && m_TimetoAgimat <= Time.time)
        {
            Play("Material");
            m_TimetoAgimat = Time.time + 30f;
            StartCoroutine(Managers.Instance.uiManager.AgimatProgressBar(m_TimetoAgimat));
            PlayerHealth.Instance.isAgimatActive = true;
            PlayerPrefasManager.Instance.Agimat = -1;
            Managers.Instance.uiManager.Agimat();
        }
    }

    public void MaterialInfo(string ContainerName)
    {
        string value = PlayerPrefasManager.Instance.InventoryContainer(ContainerName);
        
        if(!string.IsNullOrEmpty(value))
            Managers.Instance.inventoryManager.MaterialInfo(int.Parse(value));
    }

    public void CraftMaterial(int Index)
    {
        Managers.Instance.craftManager.CraftMaterial(Index);
    }

    public void Craft()
    {
        Managers.Instance.craftManager.Craft();
    }

    public void Objective(int _level)
    {
       StartCoroutine(Managers.Instance.uiManager.Objective(_level));
    }

    private void Play(string _sound)
    {
        Managers.Instance.audioManager.Play(_sound);
    }

    private void DeleteKey(string _key)
    {
        PlayerPrefs.DeleteKey(_key);
    }
}
