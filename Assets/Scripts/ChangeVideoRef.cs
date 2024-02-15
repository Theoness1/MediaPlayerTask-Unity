using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVideoRef : MonoBehaviour
{
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private Video _videos;
    [SerializeField] private PrintVideoName _printVideoName;
    private static int? _currentClipNum;

    private void Start()
    {
        _printVideoName = GameObject.Find("VideoNameText").GetComponent<PrintVideoName>();
    }

    public void ChangeVideoReference(int clipNum) {
        if (clipNum != _currentClipNum)
        {
            PlayButton.IsFirstSession = false;
            _mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, _videos.Clip[clipNum].originalPath, true);
            _printVideoName.DeleteSymbolsInName(_videos.Clip[clipNum].name);
            CollapseButton.Instance.CollapsePanel();
            _currentClipNum = clipNum;
        }
    }
}
