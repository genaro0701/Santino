using UnityEngine;
using DG.Tweening;
using System.Collections;

public class UITransitionManager : MonoBehaviour
{
    [SerializeField] private float fadeTime = 1f, weaponFadeTime = .1f;
    [SerializeField] private GameObject[] m_ButtonWeapons;

    private bool m_FadeComplete = true;

    private IEnumerator Disable(GameObject _weapons, float _seconds = 0)
    {
        yield return new WaitForSeconds(_seconds);
        _weapons.SetActive(false);
        SantinoWeaponsReset();
    }

    private IEnumerator SantinoWeaponFadeIn()
    {
        int weapon = PlayerPrefasManager.Instance.PlayerWeapon;

        for (int i = 1; i <= weapon; i++)
        {
            yield return new WaitForSeconds(weaponFadeTime);
            m_ButtonWeapons[i - 1].GetComponent<CanvasGroup>().DOFade(1, weaponFadeTime).SetUpdate(true);
        }
    }

    private void SantinoWeaponsReset()
    {
        for (int i = 0; i < m_ButtonWeapons.Length; i++)
        {
            m_ButtonWeapons[i].GetComponent<CanvasGroup>().alpha = .3f;
        }
    }

    public void FadeIn(GameObject obj)
    {
        if (m_FadeComplete)
        {
            m_FadeComplete = false;
            obj.GetComponent<CanvasGroup>().alpha = 0;
            obj.SetActive(true);
            obj.GetComponent<CanvasGroup>().DOFade(1, fadeTime).SetUpdate(true).OnComplete(() => m_FadeComplete = true);
        }
    }

    public void FadeOut(GameObject obj)
    {
        if (m_FadeComplete)
        {
            m_FadeComplete = false;
            obj.GetComponent<CanvasGroup>().DOFade(0, fadeTime).OnComplete(() => {
                obj.SetActive(false);
                m_FadeComplete = true;
                }).SetUpdate(true);
        }
    }

    public void ChangeWeapon(GameObject _weapons)
    {
        if (_weapons.activeInHierarchy)
        {
            StopCoroutine(Disable(_weapons));
            StartCoroutine(Disable(_weapons));
        }
        else
        {
            _weapons.SetActive(true);
            StartCoroutine(SantinoWeaponFadeIn());
            StartCoroutine(Disable(_weapons, 6f));
        }
    }
}
