using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : Managers
{
    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;
    public AudioSource backgroundMusic;
    public AudioSource levelUp;
    public static AudioManager instance;

    [Range(-80,10)]
    public float masterVol, effectsVol;
    public Slider masterSldr, effectsSldr;
    // Start is called before the first frame update

    protected virtual void Update()
    {
        MasterVolume();
        EffectsVolume();
    }

    private void Start()
    {
        playAudio(backgroundMusic);
        masterSldr.value = masterVol;
        effectsSldr.value = effectsVol;

        masterSldr.minValue = -80;
        masterSldr.maxValue = 10;
        effectsSldr.minValue = -80;
        effectsSldr.maxValue = 10;

    }

    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
    }

    public void playAudio(AudioSource audio)
    {
        audio.Play();
    }

    public void MasterVolume()
    {
        musicMixer.SetFloat("musicVolume", masterSldr.value); 
    }

    public void EffectsVolume()
    {
        effectsMixer.SetFloat("effectsVolume", effectsSldr.value);
    }
}
