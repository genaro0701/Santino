using UnityEngine;

public class KapreAudio : MonoBehaviour
{
    public void KapreRun()
    {
        Play("KapreRun");
    }

    public void KapreAttack()
    {
        Play("KapreAttack");
    }

    public void KapreDie()
    {
        Play("KapreDie");
    }

    private void Play(string name)
    {
        Managers.Instance.audioManager.Play(name);
    }
}
