using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatibatAudio : MonoBehaviour
{
    public void BatibatLaugh()
    {
        Managers.Instance.audioManager.Play("BatibatLaugh");
    }

    public void BatibatRun()
    {
        Managers.Instance.audioManager.Play("BatibatWalk");
    }
}
