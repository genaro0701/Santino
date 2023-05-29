using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Check Point", menuName = "Level Check Point")]
public class LevelCheckPoint : ScriptableObject
{
    public List<CheckPoint> Position;

    [System.Serializable]
    public class CheckPoint
    {
        public int level;
        public List<Vector2> checkPoint;

        public CheckPoint(int level, List<Vector2> checkpoint)
        {
            this.level = level;
            this.checkPoint = checkpoint;
        }
    }
}
