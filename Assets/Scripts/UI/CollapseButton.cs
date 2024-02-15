using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseButton : MonoBehaviour
{
    public static CollapseButton Instance;
    public bool IsCollapsed = false;
    [SerializeField] private MediaPlayer _mediaPlayer;
    [SerializeField] private RectTransform _videoPanel;
    [SerializeField] private GameObject[] _clickableButtons;
    private float _xPos;
    private float _panelWidth;

    private void Start()
    {
        _clickableButtons = GameObject.FindGameObjectsWithTag("ClickableButton");
        _xPos = _videoPanel.position.x;
        _panelWidth = _videoPanel.rect.width;
    }
    
    public CollapseButton() {
        Instance = this;
    }

    public void PlayPauseVideo() {
        if(IsCollapsed)
            _mediaPlayer.Play();
        else
            _mediaPlayer.Pause();
    }

    public void CollapsePanel()
    {
        if (IsCollapsed == false)
        {
            OnOffButtons(false);
            _videoPanel.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, 0);
            IsCollapsed = true;
        }
        else
        {
            OnOffButtons(true);
            _videoPanel.position = new Vector2(_xPos, _videoPanel.position.y);
            _videoPanel.sizeDelta = new Vector2(_panelWidth, _videoPanel.sizeDelta.y);
            IsCollapsed = false;
        }
    }

    private void OnOffButtons(bool active) {
        for (int i = 0; i < _clickableButtons.Length; i++)
        {
            _clickableButtons[i].SetActive(active);
        }
    }
}
