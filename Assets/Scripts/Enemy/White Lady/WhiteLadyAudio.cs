using UnityEngine;

public class WhiteLadyAudio : MonoBehaviour
{
    public void Idle()
    {
        Managers.Instance.audioManager.Play("WhiteLadyIdle");
    }
}
