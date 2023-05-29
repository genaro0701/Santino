using UnityEngine;

[CreateAssetMenu(fileName = "Loading Screen")]
public class LoadingScreen :ScriptableObject
{
    public Sprite[] backgroundImage;
    [TextArea(0,10)]
    public string[] tips;
}
