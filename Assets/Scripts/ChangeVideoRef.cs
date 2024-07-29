using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class ChangeVideoRef : MonoBehaviour
{
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private CloudVideoData _cloudVideoData;
    [SerializeField] private PrintVideoName _printVideoName;
    [SerializeField] private CollapseButton _collapseButton;
    private static int? _currentClipNum;

    public void ChangeVideoReference(int clipNum) {
        if (clipNum != _currentClipNum)
        {
            PlayButton.IsFirstSession = false;
            _mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, _cloudVideoData.ClipsURL[clipNum], false);
            _printVideoName.DeleteSymbolsInName(_cloudVideoData.ClipsURL[clipNum]);
            _collapseButton.CollapsePanel();
            _currentClipNum = clipNum;
        }
    }
}
