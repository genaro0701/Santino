using UnityEngine;

public class NunoAudio : MonoBehaviour
{
    public void Idle()
    {
        Play("NunoIdle");
    }

    public void Attack()
    {
        Play("NunoAttack");
    }

    public void FallingRock()
    {
        Play("FallingRock");
    }

    private void Play(string _sound)
    {
        Managers.Instance.audioManager.Play(_sound);
    }
}
