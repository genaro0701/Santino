using UnityEngine;

public class BungisngisAudio : MonoBehaviour
{
    public void Attack()
    {
        Play("BungisngisAttack");
    }
    public void Walk()
    {
        Play("BungisngisRun");
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
