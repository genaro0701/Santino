using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Stats m_EnemyStats;
    [SerializeField] private Objective m_Objective;

    [SerializeField] private GameObject m_GamePlayPanel;
    [SerializeField] private GameObject m_GameOverPanel;
    [SerializeField] private GameObject m_LevelCompletePanel;
    [SerializeField] private GameObject m_TutorialPanel;
    [SerializeField] private GameObject m_SkillCdPanel;
    [SerializeField] private GameObject m_UltimateCdPanel;
    [SerializeField] private GameObject m_EnemyHealthPanel;
    [SerializeField] private GameObject m_PagePanel;
    [SerializeField] private GameObject m_ObjectiveDescription;

    [SerializeField] private GameObject m_LevelComplete;

    [SerializeField] private GameObject m_HealthIndicator;

    [SerializeField] private Image m_SantinoFill;
    [SerializeField] private Image m_IndicatorSprite;
    [SerializeField] private Image m_EnemyFill;

    [SerializeField] private Slider m_SantinoSlider;
    [SerializeField] private Slider m_EnemySlider;
    [SerializeField] private Slider m_AgimatProgressBar;

    [SerializeField] private TextMeshProUGUI m_BinhiTxt;
    [SerializeField] private TextMeshProUGUI m_BinhiNotif;
    [SerializeField] private TextMeshProUGUI m_LangisTxt;
    [SerializeField] private TextMeshProUGUI m_AgimatTxt;
    [SerializeField] private TextMeshProUGUI m_Skilltxt;
    [SerializeField] private TextMeshProUGUI m_Ultimatext;
    [SerializeField] private TextMeshProUGUI m_EnemyName;
    [SerializeField] private TextMeshProUGUI m_PageTxt;
    [SerializeField] private TextMeshProUGUI m_PlayersName;
    [SerializeField] private TextMeshProUGUI m_SantinoHp;
    [SerializeField] private TextMeshProUGUI m_Message;

    [SerializeField] private CanvasGroup m_IndicatorCanvasGroup;

    [SerializeField] private Gradient[] m_HealthGradient;

    [SerializeField] private Sprite[] m_HealthSprite;

    private bool isActive = false;

    public void PlayersName()
    {
        m_PlayersName.text = PlayerPrefasManager.Instance.PlayerName;
    }

    public void BinhiOnload()
    {
        int binhi = PlayerPrefasManager.Instance.Binhi;
        m_BinhiTxt.text = binhi.ToString();
    }

    public void SetBinhi(int binhi)
    {
        m_BinhiNotif.text = "+ " + binhi.ToString();
        Invoke(nameof(Binhi), 3f);
        BinhiOnload();
    }

    public void Binhi()
    {
        m_BinhiNotif.text = "";
    }

    public void Langis()
    {
        m_LangisTxt.text = PlayerPrefasManager.Instance.Langis.ToString();
    }

    public void Agimat()
    {
        m_AgimatTxt.text = PlayerPrefasManager.Instance.Agimat.ToString();
    }

    public void Tutorial()
    {

        string tutorial = PlayerPrefasManager.Instance.Tutorial;

        if (!string.IsNullOrEmpty(tutorial))
        {
            m_TutorialPanel.SetActive(false);
            m_GamePlayPanel.SetActive(true);
        }
        else
        {
            m_GamePlayPanel.SetActive(false);
            m_TutorialPanel.SetActive(true);
        }
    }

    public void PlayersHealth(float _health)
    {
        m_SantinoSlider.value = _health;
        m_SantinoHp.text = _health + "%";
        m_SantinoFill.color = m_HealthGradient[0].Evaluate(m_SantinoSlider.normalizedValue);

        if (_health <= 30 && _health > 0)
        {
            if (!m_HealthIndicator.activeInHierarchy)
                m_HealthIndicator.SetActive(true);

            if (_health < 30 && _health > 20)
                m_IndicatorSprite.sprite = m_HealthSprite[0];
            
            else if (_health < 20 && _health > 10)
                m_IndicatorSprite.sprite = m_HealthSprite[1];

            else if (_health < 10)
                m_IndicatorSprite.sprite = m_HealthSprite[2];
            
            if (isActive == false)
            {
                isActive = true;
                m_IndicatorCanvasGroup.DOFade(0, 1f).OnComplete(() =>
                {
                    m_IndicatorCanvasGroup.alpha = 1;
                    m_IndicatorCanvasGroup.DORestart();
                });
            }
        }

        else
        {
            if (m_HealthIndicator.activeInHierarchy)
            {
                m_HealthIndicator.SetActive(false);
                m_IndicatorCanvasGroup.DOPause();
            }
        }
    }

    public void EnemyHealth(int _health, string _name)
    {
        if (!m_EnemyHealthPanel.activeInHierarchy)
        {
            m_EnemyHealthPanel.SetActive(true);
            m_EnemyName.text = _name;

            switch (_name)
            {
                case "Bungisngis":
                    m_EnemySlider.maxValue = m_EnemyStats.bungisngis.health;
                    break;
                case "King Bungisngis":
                    m_EnemySlider.maxValue = m_EnemyStats.bossBungisngis.health;
                    break;
                case "Kapre":
                    m_EnemySlider.maxValue = m_EnemyStats.kapre.health;
                    break;
                case "King Kapre":
                    m_EnemySlider.maxValue = m_EnemyStats.bossKapre.health;
                    break;
                case "Pugot":
                    m_EnemySlider.maxValue = m_EnemyStats.mob.health;
                    break;
                case "King Tiktik":
                    m_EnemySlider.maxValue = m_EnemyStats.bossTiktik.health;
                    break;
            }
        }

        if (_health > 0)
            m_EnemySlider.value = _health;
        else
            m_EnemyHealthPanel.SetActive(false);


        switch (_name)
        {
            case "Bungisngis":
                m_EnemyFill.color = m_HealthGradient[1].Evaluate(m_EnemySlider.normalizedValue);
                break;
            case "King Bungisngis":
                m_EnemyFill.color = m_HealthGradient[1].Evaluate(m_EnemySlider.normalizedValue);
                break;
            case "Kapre":
                m_EnemyFill.color = m_HealthGradient[2].Evaluate(m_EnemySlider.normalizedValue);
                break;
            case "King Kapre    ":
                m_EnemyFill.color = m_HealthGradient[3].Evaluate(m_EnemySlider.normalizedValue);
                break;
            case "Pugot":
                m_EnemyFill.color = m_HealthGradient[4].Evaluate(m_EnemySlider.normalizedValue);
                break;
            case "King Tiktik":
                m_EnemyFill.color = m_HealthGradient[5].Evaluate(m_EnemySlider.normalizedValue);
                break;
        }
    }

    public void GameOver()
    {
        m_GamePlayPanel.SetActive(false);
        m_GameOverPanel.SetActive(true);
        Managers.Instance.audioManager.Play("GameOver");
    }

    public void LevelComplete()
    {
        m_GamePlayPanel.SetActive(false);
        m_LevelCompletePanel.SetActive(true);
        Managers.Instance.audioManager.Pause("BGM");
        Managers.Instance.audioManager.Play("LevelComplete");
    }

    //Skill CoolDown 
    public IEnumerator CoolDownSkill(float time)
    {
        m_SkillCdPanel.SetActive(true);
        m_SkillCdPanel.GetComponent <Image>().DOFillAmount(0, time - Time.time).OnComplete(() => m_SkillCdPanel.GetComponent <Image>().fillAmount = 1);

        while (time > Time.time)
        {
            m_Skilltxt.text = (Mathf.Abs((int)(time - Time.time))).ToString();
            yield return null;
        }

        m_SkillCdPanel.SetActive(false);
        m_Skilltxt.text = "";
    }

    //Ultimate CoolDown
    public IEnumerator CoolDownUltimate(float time)
    {
        m_UltimateCdPanel.SetActive(true);
        m_UltimateCdPanel.GetComponent <Image>().DOFillAmount(0, time - Time.time).OnComplete(() => m_UltimateCdPanel.GetComponent<Image>().fillAmount = 1);

        while (time > Time.time)
        {
            m_Ultimatext.text = (Mathf.Abs((int)(time - Time.time))).ToString();
            yield return null;
        }

        m_UltimateCdPanel.SetActive(false);
        m_Ultimatext.text = "";
    }

    public IEnumerator AgimatProgressBar(float time)
    {
        m_AgimatProgressBar.value = 30;

        while (time > Time.time)
        {
            m_AgimatProgressBar.value = time - Time.time;
            yield return null;
        }

        PlayerHealth.Instance.isAgimatActive = false;
    }

    public void Page()
    {
        int page = PlayerPrefasManager.Instance.Page;
        m_PagePanel.SetActive(true);

        m_PagePanel.GetComponentInChildren<RectTransform>().DOShakeAnchorPos(1f, 50f);
        m_PageTxt.text = page + "/15";

        if (page >= 15)
        {
            m_PagePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(() => m_PagePanel.SetActive(false));
            m_LevelComplete.SetActive(true);
            FindObjectOfType<ButtonManager>().Objective(0);
        }
    }

    public void LevelCompletePortal()
    {
        m_LevelComplete.SetActive(true);
    }

    public IEnumerator Objective(int _index)
    {
        m_ObjectiveDescription.GetComponent<TextMeshProUGUI>().text = m_Objective.description[_index];
        m_ObjectiveDescription.GetComponent<RectTransform>().DOAnchorPosX(540.446f, 1f);
        yield return new WaitForSeconds(5f);
        m_ObjectiveDescription.GetComponent<TextMeshProUGUI>().text = null;
        m_ObjectiveDescription.GetComponent<RectTransform>().position = new(-431.9f, m_ObjectiveDescription.GetComponent<RectTransform>().position.y);
    }

    public IEnumerator Message(string _message, float _duration = 2f)
    {
        m_Message.text = _message;
        yield return new WaitForSeconds(_duration);
        m_Message.text = null;
    }
}
