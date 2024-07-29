using UnityEngine;

[CreateAssetMenu(fileName = "CloudVideoData", menuName = "ScriptableObjects/CloudVideoData", order = 2)]
public class CloudVideoData : ScriptableObject
{
    public string[] ClipsURL;
    public string[] ClipNames;
}
