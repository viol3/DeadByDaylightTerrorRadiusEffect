using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransitorSerial : SoundTransitorBase
{
    // using only one audio source and there is no fade transition

    protected AudioSource _audioSource;
    protected override void Awake()
    {
        base.Awake();
        if (GetComponent<AudioSource>() == null)
        {
            gameObject.AddComponent<AudioSource>();
        }
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.loop = true;
        UpdateSourceClip();
        _audioSource.Play();
    }

    protected override void UpdateSourceClip()
    {
        _audioSource.Pause();
        float time = _audioSource.time;
        _audioSource.clip = _audioClips[_currentClipIndex];
        _audioSource.time = time;
        _audioSource.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
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
