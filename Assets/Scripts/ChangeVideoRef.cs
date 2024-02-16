using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class ChangeVideoRef : MonoBehaviour
{
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private Video _videos;
    [SerializeField] private PrintVideoName _printVideoName;
    private static int? _currentClipNum;

    public void ChangeVideoReference(int clipNum) {
        if (clipNum != _currentClipNum)
        {
            PlayButton.IsFirstSession = false;
            _mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, _videos.Clip[clipNum].originalPath, false);
            _printVideoName.DeleteSymbolsInName(_videos.Clip[clipNum].name);
            CollapseButton.Instance.CollapsePanel();
            _currentClipNum = clipNum;
        }
    }
}
