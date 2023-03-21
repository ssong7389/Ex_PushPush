using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioManager _instance = null;
    public float volume;
    public float sfxVolume;
    AudioSource source;
    public AudioClip intro;
    public AudioClip main;
    public AudioClip dead;
    public AudioClip lose;
    public AudioClip beep;
    public DdongManager dm;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Debug.Log("Destroy " + GetHashCode());
            Destroy(gameObject);
        }
        source = GetComponent<AudioSource>();
        source.loop = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if (source != null)
            source.volume = volume;
        if(scene.buildIndex == 0)
        {           
            source.clip = intro;
            source.loop = true;
            if (source.isPlaying)
                source.Stop();
            source.Play();
        }
        else
        {
            dm = GameObject.Find("DdongManager").GetComponent<DdongManager>();
            dm.bgmSlider.value = volume;
            dm.bgmSlider.onValueChanged.AddListener(OnBgmChanged);
            dm.sfxSlider.value = sfxVolume;
            dm.sfxSlider.onValueChanged.AddListener(OnSfxChanged);
            source.clip = main;
            source.loop = true;
            if (source.isPlaying)
                source.Stop();
            source.PlayDelayed(5f);
        }
    }
    public void Lose()
    {
        source.volume = volume;
        source.clip = lose;
        source.loop = false;
        if (source.isPlaying)
            source.Stop();
        source.PlayOneShot(lose, volume);
    }
    public void Dead()
    {
        source.volume = volume;
        source.clip = dead;
        source.loop = false;
        if (source.isPlaying)
            source.Stop();
        source.PlayDelayed(2f);
    }
    public void OnBgmChanged(float vol)
    {
        if(volume==0 && vol > 0)
        {
            dm.bgmImage.sprite = Resources.Load<Sprite>("Sprites/sound");
        }
        volume = vol;
        source.volume = volume;
    }
    public void OnSfxChanged(float vol)
    {
        if (sfxVolume == 0 && vol > 0)
        {
            dm.sfxImage.sprite = Resources.Load<Sprite>("Sprites/sound");
        }
        sfxVolume = vol;
    }
    public void Beep()
    {
        source.PlayOneShot(beep, volume);
    }

}
