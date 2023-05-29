using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup[] m_AudioMixer;
    [SerializeField] private Slider[] m_Volume;

    private void Awake()
    {
        float masterVolume = PlayerPrefasManager.Instance.MasterVolume;
        float bgmVolume = PlayerPrefasManager.Instance.BGMVolume;
        float sfxVolume = PlayerPrefasManager.Instance.SFXVolume;

        MasterVolume(masterVolume);
        BGM(bgmVolume);
        SFX(sfxVolume);

        m_Volume[0].value = masterVolume;
        m_Volume[1].value = bgmVolume;
        m_Volume[2].value = sfxVolume;
    }

    //Sound settting 
    public void MasterVolume(float volume)
    {
        m_AudioMixer[0].audioMixer.SetFloat("MasterVolume", volume);
        PlayerPrefasManager.Instance.MasterVolume = volume;
    }

    public void BGM(float volume)
    {
        m_AudioMixer[1].audioMixer.SetFloat("BGM", volume);
        PlayerPrefasManager.Instance.BGMVolume = volume;
    }

    public void SFX(float volume)
    {
        m_AudioMixer[2].audioMixer.SetFloat("SFX", volume);
        PlayerPrefasManager.Instance.SFXVolume = volume;
    }
}
