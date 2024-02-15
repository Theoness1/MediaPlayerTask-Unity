using RenderHeads.Media.AVProVideo;
using RenderHeads.Media.AVProVideo.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public static bool IsFirstSession = true;
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private MediaPlayerUI _mediaPlayerUI;
    [SerializeField] private ChangeVideoRef _changeVideoRef;

    public void PlayFirst() {
        if(IsFirstSession) {
            _changeVideoRef.ChangeVideoReference(0);
            CollapseButton.Instance.CollapsePanel();
            IsFirstSession = false;
        }
    }

    public void ClosePanel() {
        if(!CollapseButton.Instance.IsCollapsed)
            CollapseButton.Instance.CollapsePanel();
    }

    // should be on the event list, higher than ClosePanel
    public void ResetVideoTime() { 
        if (!CollapseButton.Instance.IsCollapsed)
            _mediaPlayer.Control.Seek(0);
    }

    public void ChangeToPauseTexture() {
        _mediaPlayerUI.TogglePlayPause();
    }
}
