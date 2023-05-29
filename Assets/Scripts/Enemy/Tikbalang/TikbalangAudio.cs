using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikbalangAudio : MonoBehaviour
{
   private void TikbalangRun()
    {
        Managers.Instance.audioManager.Play("TikbalangRun");
    }

    private void TikbalangLaugh()
    {
        Managers.Instance.audioManager.Play("TikbalangScream");
    }
}
