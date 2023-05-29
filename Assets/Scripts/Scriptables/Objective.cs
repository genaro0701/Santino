using UnityEngine;

[CreateAssetMenu(fileName = "Objective")]
public class Objective : ScriptableObject
{
    [TextArea(0, 10)]
    public string[] description;
}
