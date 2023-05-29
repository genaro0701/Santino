using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelCheckPoint m_LevelCheckPoint;
    [SerializeField] private Transform m_Santino;
    [SerializeField] private int m_CurrentLevel;

    private int m_SavedLevel;
    private float m_SavedHealth;

    private UIManager _uiManagers;
    private PlayerPrefasManager _playerPrefsManager;
    private PlayerMovement _playerMovement;
    private TransitionManager _transitionManager;

    private void Awake()
    {
        _playerPrefsManager = PlayerPrefasManager.Instance;

        m_SavedLevel = _playerPrefsManager.Level;

        if (m_SavedLevel == 0)
        {
            m_SavedLevel = 1;
            _playerPrefsManager.Level = m_SavedLevel;
        }

        if (m_CurrentLevel > 0)
        {
            _uiManagers = Managers.Instance.uiManager;
            _playerMovement = PlayerMovement.Instance;
            _transitionManager = Managers.Instance.transitionManager;

            SantinoComponent();
            LevelComponent();
            LoadUIMaterial();
            LoadInventory();
        }
    }

    private void Start()
    {
        if (m_CurrentLevel > 0)
        {
            BGM();
            FindObjectOfType<ButtonManager>().Objective(m_CurrentLevel);
        }

    }


    private void BGM()
    {
        Play("BGM");
    }

    private void SantinoComponent()
    {
        if (_playerPrefsManager.PlayerWeapon == 0)
        {
            _playerPrefsManager.PlayerWeapon = 1;
            _playerPrefsManager.ChangeWeapon = 1;
        }

        //Load Players Name
        _uiManagers.PlayersName();

        //Load Health
        m_SavedHealth = PlayerHealth.Instance.LoadHealth(m_CurrentLevel, m_SavedLevel);

        //Load Player Weapon
        PlayerAnimation.Instance.SantinoChangeWeapon(_playerPrefsManager.ChangeWeapon);
    }

    private void LevelComponent()
    {
        //Set current level and saved level to other script
        _playerMovement.currentlevel = m_CurrentLevel;
        _playerMovement.savedlevel = m_SavedLevel;
        _transitionManager.currentLevel = m_CurrentLevel;
        _transitionManager.savedLevel = m_SavedLevel;


        //Get frame
        int savedFrame = _playerPrefsManager.FrameSaved;
        int currentFrame = _playerPrefsManager.CurrentFrame;


        if (m_CurrentLevel == m_SavedLevel)
        {
            _playerPrefsManager.CurrentFrame = 0;
            if (savedFrame > 0) _transitionManager.SetFrame(savedFrame);
            if (m_SavedHealth <= 0 && savedFrame > 0) m_Santino.position = m_LevelCheckPoint.Position[m_CurrentLevel].checkPoint[savedFrame];

            //Get Player Position
            float x = _playerPrefsManager.PositionX;
            float y = _playerPrefsManager.PositionY;

            if (x > 0 || x < 0 || y > 0 || x < 0)
                //set player postion
                m_Santino.position = new Vector2(x, y);
        }
        else
        {
            //load level frame
            if (currentFrame > 0)
            {
                _transitionManager.SetFrame(currentFrame);
                m_Santino.position = m_LevelCheckPoint.Position[m_CurrentLevel].checkPoint[currentFrame];
            }
        }
    }


    private void LoadUIMaterial()
    {
        //int binhi = _playerPrefsManager.Binhi;
        //if (binhi == 0)
        //    _playerPrefsManager.Binhi = 99999;
        
        _uiManagers.Tutorial();
        _uiManagers.Langis();
        _uiManagers.Agimat();
        _uiManagers.BinhiOnload();
    }

    private void LoadInventory()
    {
        Managers.Instance.inventoryManager.Inventory();
    }

    private void Play(string Name)
    {
        Managers.Instance.audioManager.Play(Name);
    }
}
