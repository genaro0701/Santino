using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class MapManager : MonoBehaviour
{
    [SerializeField] private PlayerInput _PlayerInput;

    [SerializeField] private GameObject m_Confirmation;

    [SerializeField] private float m_FadeTime = 1f, m_PosX = 1400f;
    [SerializeField] private List<Stages> m_SelectableLevel = new List<Stages>();

    private InputAction touchPressAction, touchStartPositionAction, touchEndPostionAction;
    private Vector2 startTouchPostion, EndTouchPostion;
    private List<Vector2> m_LevelDefualtPos = new List<Vector2>();
    private bool swipeRight, swipeLeft;
    private int i, stage = 0, selectedLevel;

    private void Awake()
    {
        touchPressAction = _PlayerInput.actions["TouchPress"];
        touchStartPositionAction = _PlayerInput.actions["TouchStartPosition"];
        touchEndPostionAction = _PlayerInput.actions["TouchEndPosition"];

        Levels();
    }

    //Subscribe to event
    private void OnEnable()
    {
        touchPressAction.performed += TouchPress;
    }

    //Unsubscribe to event
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPress;
    }

    private void TouchPress(InputAction.CallbackContext context)
    {
        startTouchPostion = touchStartPositionAction.ReadValue<Vector2>();
        EndTouchPostion = touchEndPostionAction.ReadValue<Vector2>();

        //Swipe Right
        if (startTouchPostion.x > EndTouchPostion.x && startTouchPostion != EndTouchPostion)
        {
            if (i < 2)
            {
                swipeRight = true;
                StartCoroutine(OnSwipe());
            }
        }

        //Swipe Left
        if (startTouchPostion.x < EndTouchPostion.x)
        {
            if (i > 0)
            {
                swipeLeft = true;
                StartCoroutine(OnSwipe());
            }
        }
    }

    //Move out current level and move in new level
    private IEnumerator OnSwipe()
    {
        yield return new WaitForSeconds(1);

        if (swipeRight)
        {
            swipeRight = false;

            //Move level on center to left
            MoveOnSwipe(-m_PosX, m_FadeTime, Ease.OutSine);
            i++;

            //Move level on the right to center
            UnLockOnSwipe(Ease.InSine);

            //Enable level on the right
            if (i <= 1)
            {
                m_SelectableLevel[stage].levels[2].SetActive(true);
                m_SelectableLevel[stage].levels[2].GetComponent<RectTransform>().DOAnchorPos(new Vector2(m_PosX, 0f), m_FadeTime).SetEase(Ease.InSine);
            }

            //Disable level on the left
            if (i >= 2)
            {
                m_SelectableLevel[stage].levels[0].SetActive(false);
                m_SelectableLevel[stage].levels[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-m_PosX + -200f, 0f);
            }
        }

        if (swipeLeft)
        {
            swipeLeft = false;
            //Move level on the center to right
            MoveOnSwipe(m_PosX, m_FadeTime * .5f, Ease.InSine);
            i--;
            //Move level on the left to center
            UnLockOnSwipe(Ease.OutSine);

            //Enable level on the left
            if (i == 1)
            {
                m_SelectableLevel[stage].levels[0].SetActive(true);
                m_SelectableLevel[stage].levels[0].GetComponent<RectTransform>().DOAnchorPos(new Vector2(-m_PosX, 0f), m_FadeTime).SetEase(Ease.InSine);
            }

            //disable level right
            if (i == 0)
            {
                m_SelectableLevel[stage].levels[2].SetActive(false);
                m_SelectableLevel[stage].levels[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(m_PosX + 200f, 0f);
            }
        }
    }

    private void MoveOnSwipe(float _pos, float _fadeTime, Ease _ease)
    {
        m_SelectableLevel[stage].levels[i].GetComponent<RectTransform>().DOAnchorPos(new Vector2(_pos, 0f), _fadeTime).SetEase(_ease);
        m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().alpha = 0.5f;
    }

    private void UnLockOnSwipe(Ease ease)
    {
        m_SelectableLevel[stage].levels[i].GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, m_FadeTime).SetEase(ease).OnComplete(() =>
        {
            //Low opacity for not unlocked level
            int level = PlayerPrefasManager.Instance.Level;

            if (level >= (i + 1) && stage == 0)
                m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().DOFade(1, m_FadeTime);

            else if (level >= 4 && stage == 1)
            {
                level -= 3;

                if (level >= (i + 1))
                    m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().DOFade(1, m_FadeTime);
            }
            else if (level >= 7 && stage == 2)
            {
                level -= 6;

                if (level >= (i + 1))
                    m_SelectableLevel[2].levels[i].GetComponent<CanvasGroup>().DOFade(1, m_FadeTime);
            }
        });
    }

    public void Stage(int _stage)
    {
        stage = _stage;
        m_SelectableLevel[stage].stage.SetActive(true);
        int level = PlayerPrefasManager.Instance.Level;

        //Set yung alpha sa 1 nung first na level sa stage kung unlock na
        if (stage == 0)
            m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().DOFade(1, 1f);
        else if (stage == 1 && level >= 4)
            m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().DOFade(1, 1f);
        else if (stage == 2 && level >= 7)
            m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().DOFade(1, 1f);
    }

    private void Reset()
    {
        //Enable ulit yung first level sa stage kapag nag swipe na ng dalawang beses
        if (i == 2)
            m_SelectableLevel[stage].levels[0].SetActive(true);

        //Reset yung alpha nung 1st and 2nd na level
        for (int i = 0; i < 2; i++)
        {
            m_SelectableLevel[stage].levels[i].GetComponent<CanvasGroup>().alpha = .5f;
        }

        int j;

        //Reset lahat ng level anchorpos
        for (int i = 0; i < m_SelectableLevel[stage].levels.Count; i++)
        {
            j = i;

            if (stage == 1) j += 3;
            else if (stage == 2) j += 6;
                
            m_SelectableLevel[stage].levels[i].GetComponent<RectTransform>().anchoredPosition = m_LevelDefualtPos[j];
        }
    }

    public void LevelConfirm(int _level)
    {
        selectedLevel = _level;

        if (PlayerPrefasManager.Instance.Level >= selectedLevel)
            m_Confirmation.SetActive(true);
    }

    public void LevelSelected()
    {
        Managers.Instance.audioManager.Play("Button");
        Managers.Instance.audioManager.UnPause("BGM");
        gameObject.SetActive(false);
        Managers.Instance.levelLoader.LoadLevel(selectedLevel);
        PlayerPrefs.DeleteKey("CurrentFrame");
        gameObject.SetActive(false);
    }

    private void Levels()
    {
        for (int i = 0; i < m_SelectableLevel.Count; i++)
        {
            for (int j = 0; j < m_SelectableLevel[i].levels.Count; j++)
            {
                m_LevelDefualtPos.Add(m_SelectableLevel[i].levels[j].GetComponent<RectTransform>().anchoredPosition);
            }
        }
    }

    public void Back()
    {
        m_SelectableLevel[stage].stage.SetActive(false);

        Reset();

        //zero yung swipe
        i = 0;
    }
    

    [System.Serializable]
    public class Stages
    {
        public GameObject stage;
        public List<GameObject> levels;
    }
}
