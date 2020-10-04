using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransitorParallel : SoundTransitorBase
{
    // using multiple audio sources and there is possibility to do fade animation between sounds

    [SerializeField] private float _fadeDuration = 0.3f;

    protected AudioSource[] _audioSources;

    protected override void Awake()
    {
        base.Awake();
        _audioSources = new AudioSource[_audioClips.Length];
        for (int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = gameObject.AddComponent<AudioSource>();
            _audioSources[i].playOnAwake = false;
            _audioSources[i].loop = true;
            _audioSources[i].clip = _audioClips[i];
            _audioSources[i].volume = 0f;
            _audioSources[i].Play();
        }
        UpdateSourceClip();
    }
    protected override void UpdateSourceClip()
    {
        for (int i = 0; i < _audioSources.Length; i++)
        {
            if(i == _currentClipIndex)
            {
                _audioSources[i].DOKill();
                _audioSources[i].DOFade(1f, _fadeDuration);
            }
            else
            {
                _audioSources[i].DOKill();
                _audioSources[i].DOFade(0f, _fadeDuration);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RaiseIndex(1);
            UpdateSourceClip();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RaiseIndex(-1);
            UpdateSourceClip();
        }
    }
}
