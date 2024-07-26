using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoData", menuName = "ScriptableObjects/VideoData", order = 1)]
public class VideoData : ScriptableObject
{
    public VideoClip[] Clips;
    public Sprite[] Previews;
    public string[] ClipNames;
}
