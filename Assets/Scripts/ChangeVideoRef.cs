using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class ChangeVideoRef : MonoBehaviour
{
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private VideoData _videoData;
    [SerializeField] private PrintVideoName _printVideoName;
    [SerializeField] private CollapseButton _collapseButton;
    private static int? _currentClipNum;

    public void ChangeVideoReference(int clipNum) {
        if (clipNum != _currentClipNum)
        {
            PlayButton.IsFirstSession = false;
            _mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, _videoData.Clips[clipNum].originalPath, false);
            _printVideoName.DeleteSymbolsInName(_videoData.Clips[clipNum].name);
            //Debug.Log(_videoData.ClipNames[clipNum]);
            _collapseButton.CollapsePanel();
            _currentClipNum = clipNum;
        }
    }
}
