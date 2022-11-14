using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllAudioManager : MonoBehaviour
{
    [SerializeField]
    private MuteAudio _audioMuter;
    private AudioSource[] _allAudioSources;
    

    private void Start()
    {
        _allAudioSources = FindObjectsOfType<AudioSource>();
        _audioMuter.OnSoundMuting += OnSoundMutingAction;
        _audioMuter.OnSoundUnMuting += OnSoundUnMutingAction;
    }

    private void OnSoundMutingAction() {
        foreach (AudioSource audioSource in _allAudioSources) {
            audioSource.mute = true;
        }
    }

    private void OnSoundUnMutingAction()
    {
        foreach (AudioSource audioSource in _allAudioSources)
        {
            audioSource.mute = false;
        }
    }
}
