using TMPro;
using UnityEngine;

public class PlayersName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_PlayerName;
    [SerializeField] private GameObject m_Map, m_MainMenu;
    private string m_Santino = "Santino";

    private void OnEnable()
    {
        if (!string.IsNullOrEmpty(PlayerPrefasManager.Instance.PlayerName))
        {
            Managers.Instance.audioManager.Pause("BGM");
            m_MainMenu.SetActive(false);
            m_Map.SetActive(true);
        }
    }

    public void InputedName()
    {
        string name = m_PlayerName.text;
        name = (string.IsNullOrWhiteSpace(name)) ? m_Santino : name;
        PlayerPrefasManager.Instance.PlayerName = name;
    }
}
