using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class CutScenePlayer : MonoBehaviour
{
    [SerializeField] private VideoPlayer m_VideoPlayer;
    [SerializeField] private GameObject m_NextToEnable;
    [SerializeField] private bool m_Cinematic = false;

    private void Awake()
    {
        if (m_Cinematic)
            StartCoroutine(Cinematic());

        else if (PlayerPrefasManager.Instance.CutScene != 1)
        {
            //Disable Tutorial
            m_NextToEnable.SetActive(false);
            StartCoroutine(Player());
        }
        else
        {
            gameObject.SetActive(false);
            m_NextToEnable.SetActive(true);
        }
    }

    private IEnumerator Player()
    {
        yield return new WaitForSeconds((float)m_VideoPlayer.length);
        PlayerPrefasManager.Instance.CutScene = 1;
        gameObject.SetActive(false);
        //Play tutorial after cutscene
        m_NextToEnable.SetActive(true);
    }

    private IEnumerator Cinematic()
    {
        yield return new WaitForSeconds((float)m_VideoPlayer.length);
        gameObject.SetActive(false);
        Play("BGM");
        m_NextToEnable.SetActive(true);
    }

    private void Play(string _audio)
    {
        Managers.Instance.audioManager.Play(_audio);
    }

    public void Skip()
    {
        if (m_Cinematic)
            Play("BGM");

        gameObject.SetActive(false);
        m_NextToEnable.SetActive(true);
    }
}
