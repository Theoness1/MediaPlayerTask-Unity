using RenderHeads.Media.AVProVideo;
using RenderHeads.Media.AVProVideo.Demos;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public static bool IsFirstSession = true;
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private MediaPlayerUI _mediaPlayerUI;
    [SerializeField] private ChangeVideoRef _changeVideoRef;
    [SerializeField] private CollapseButton _collapseButton;

    public void PlayFirst() {
        if(IsFirstSession) {
            _changeVideoRef.ChangeVideoReference(0);
            _collapseButton.CollapsePanel();
            IsFirstSession = false;
        }
    }

    public void ClosePanel() {
        if(!_collapseButton.IsCollapsed)
            _collapseButton.CollapsePanel();
    }

    // should be on the event list, higher than ClosePanel
    public void ResetVideoTime() { 
        if (!_collapseButton.IsCollapsed)
            _mediaPlayer.Control.Seek(0);
    }

    public void ChangeToPauseTexture() {
        _mediaPlayerUI.TogglePlayPause();
    }
}
