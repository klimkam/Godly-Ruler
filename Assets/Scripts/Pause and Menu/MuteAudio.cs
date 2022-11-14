using System;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    public event Action OnSoundMuting;
    public event Action OnSoundUnMuting;

    [SerializeField]
    private Sprite _soundMuteIcon;
    [SerializeField]
    private Sprite _soundUnMuteIcon;

    private Image _spriteRenderer;
    private bool _isAutioMuted;

    private bool IsAudioMuted { 
        get { return _isAutioMuted; }
        set {
            if (value)
            {
                OnSoundMuting?.Invoke();
                _isAutioMuted = value;
            }
            else { 
                OnSoundUnMuting.Invoke();
                _isAutioMuted = value;
            }
        }
    }

    private void Awake()
    {
        OnSoundMuting += OnSoundMutingAction;
        OnSoundUnMuting += OnSoundUnmutingAction;
        _spriteRenderer = gameObject.GetComponent<Image>();
    }

    private void OnSoundMutingAction() {
        _spriteRenderer.sprite = _soundMuteIcon;
    }

    private void OnSoundUnmutingAction() {
        _spriteRenderer.sprite = _soundUnMuteIcon;
    }

    public void MuteButtonManager() {
        IsAudioMuted = !IsAudioMuted;
    }
}
