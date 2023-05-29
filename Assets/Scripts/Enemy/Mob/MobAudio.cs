using UnityEngine;

public class MobAudio : MonoBehaviour
{
    public void MobAttack()
    {
        Play("MobAttack");
    }

    private void Play(string name)
    {
        Managers.Instance.audioManager.Play(name);
    }
}
