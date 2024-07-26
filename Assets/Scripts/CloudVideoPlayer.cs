using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class CloudVideoPlayer : MonoBehaviour
{
    [SerializeField] MediaPlayer _mediaPlayer;
    string videoURL = "https://i.imgur.com/6uigJlD.mp4"; // рабочая
    string videoURL2 = "https://static.videezy.com/system/resources/previews/000/008/302/original/Dark_Haired_Girl_angry_-what-!-_1.mp4"; // рабочая
    string videoURL3 = "https://www.dropbox.com/scl/fi/rrhey863k62wxqd75nuo0/test.mp4";
    [SerializeField] CloudVideoData _cloudVideoData;
    private int _videoIndex = -1;

    private void Start()
    {
        //_mediaPlayer.Events.AddListener(OnVideoEvent);
        //_mediaPlayer.OpenMedia(new MediaPath(videoURL3, MediaPathType.AbsolutePathOrURL), true); // тоже рабочая но ссылку поменять
        //_mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, videoURL3, true); // РАБОЧАЯ
        /*        _mediaPlayer.Control.SetLooping(true);
                _mediaPlayer.Play();*/
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            if(_videoIndex >= _cloudVideoData.ClipsURL.Length - 1) { _videoIndex = -1; }
            ++_videoIndex;
            Debug.Log("Размер массива ссылок " + _cloudVideoData.ClipsURL.Length);
            Debug.Log(_videoIndex);
            _mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, _cloudVideoData.ClipsURL[_videoIndex], true);
        }
    }

    private void Equal(ref int currentIndex, int num) { currentIndex = num; }

    private void OnVideoEvent(MediaPlayer mediaPlayer, MediaPlayerEvent.EventType eventType, ErrorCode errorCode)
    {
        if (eventType == MediaPlayerEvent.EventType.FinishedPlaying)
        {
            mediaPlayer.Rewind(true);
            mediaPlayer.Play();
        }
    }
}
