using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Video", menuName = "ScriptableObjects/VideoScriptableObject", order = 1)]
public class Video : ScriptableObject
{
    public VideoClip[] Clip;
}
