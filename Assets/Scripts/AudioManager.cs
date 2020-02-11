using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Text masterTextVal;
    [SerializeField] private Text bgmTextVal;
    [SerializeField] private Text sfxTextVal;
    [SerializeField] private AudioMixer audioMixer;

    void Update()
    {
        SetVolume("Master", float.Parse(masterTextVal.text));
        SetVolume("BGM", float.Parse(bgmTextVal.text));
        SetVolume("SFX", float.Parse(sfxTextVal.text));
    }

    public void SetVolume (string groupName, float volume)
    {
       // if (volume > 80) volume = 80;
       // else if (volume < 0) volume = -80;
        audioMixer.SetFloat(groupName, volume-80);
    }
}
