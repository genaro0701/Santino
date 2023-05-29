using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_Frame = new List<GameObject>();
    [SerializeField] private int m_FrameCount;

    [HideInInspector] public int currentLevel;
    [HideInInspector] public int savedLevel;

    public void SetFrame(int _frame)
    {

        if (_frame == m_FrameCount || _frame > 0)
        {
            Destroy(m_Frame[0]);
        }
        
        if (_frame != 0)
        {
            Destroy(m_Frame[_frame - 1]);
            m_Frame[_frame].SetActive(true);
        }

        if (currentLevel == savedLevel)
            PlayerPrefasManager.Instance.FrameSaved = _frame;
        else
            PlayerPrefasManager.Instance.CurrentFrame = _frame;
    }
}
