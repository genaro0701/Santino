using UnityEngine;

public class BossBungisngisAudio : MonoBehaviour
{

    public void Run()
    {
        Play("BossBungisngisRun");
    }

    public void Rage()
    {
        Play("BossBungisngisRage");
    }

    public void Die()
    {
        Play("BossBungisngisDie");
    }

    public void Hurt()
    {
        Play("BungisngisHurt");
    }

    private void Play(string sound)
    {
        Managers.Instance.audioManager.Play(sound);
    }
}
