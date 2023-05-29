using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	[SerializeField] private Sound[] m_Sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		for (int i = 0; i < m_Sounds.Length; i++)
		{
            foreach (Audio s in m_Sounds[i].sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.loop = s.loop;
				//s.source.volume = s.volume;

				s.source.outputAudioMixerGroup = s.mixerGroup;
            }
        }
		
	}

	public void Play(string sound)
	{
		Audio s = Sounds(sound);

		if (s == null)
			Debug.LogWarning("Sound: " + sound + " not found!");
		else
		{
			if (!s.source.isPlaying)
			{
                s.volume *= (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
                s.source.volume = s.volume;
                s.pitch *= (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
                s.source.pitch = s.pitch;

                s.source.Play();
            }
		}
		
	}

    public void Stop(string sound)
    {
		Audio s = Sounds(sound);
		if (s != null)
			s.source.Stop();
    }

    public void UnPause(string sound)
	{
        Audio s = Sounds(sound);
        if (s != null)
           s.source.UnPause();
	}

	public void Pause(string sound)
	{
        Audio s = Sounds(sound);
        if (s != null)
			s.source.Pause();
	}

	private Audio Sounds(string sound)
    {
		for (int i = 0; i < m_Sounds.Length; i++)
			foreach (Audio s in m_Sounds[i].sounds)
				if (s.name == sound) return s;

		return null;
	}
}

[System.Serializable]
public class Audio
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = .75f;
    [Range(0f, 1f)]
    public float volumeVariance = .1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;
    [Range(0f, 1f)]
    public float pitchVariance = .1f;

    public bool loop = false;

    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource source;
}

[System.Serializable]
public class Sound
{
	public string name;
	public Audio[] sounds;
}