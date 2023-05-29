using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiktikAudio : MonoBehaviour
{
    private void TiktikLaugh()
    {
        Managers.Instance.audioManager.Play("TiktikLaugh");
    }
}
