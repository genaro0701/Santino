using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MananangalAudio : MonoBehaviour
{
    private void MananangalLaugh()
    {
        Managers.Instance.audioManager.Play("MananangalLaugh");
    }

    private void MananangalIdle()
    {
        Managers.Instance.audioManager.Play("MananangalIdle");
    }
}
