using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject m_LoadingScreen;
    [SerializeField] private Slider m_ProgressBar;
    [SerializeField] private Image m_BackgroundImg;
    [SerializeField] private TextMeshProUGUI m_TipsTxt;

    [SerializeField] private LoadingScreen m_LoadinScreenElements;

    public void LoadLevel(int LevelIndex)
    {
        StartCoroutine(LoadAsync(LevelIndex));
    }

    private IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        int rnd = Random.Range(0, m_LoadinScreenElements.backgroundImage.Length);
        m_BackgroundImg.sprite = m_LoadinScreenElements.backgroundImage[rnd];
        m_TipsTxt.text = m_LoadinScreenElements.tips[rnd];
        m_LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            m_ProgressBar.value = progress;
            yield return null;
        }

    }
}
