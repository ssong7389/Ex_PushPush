using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DdongController : MonoBehaviour
{
    public float duration;
    AudioSource source;
    AudioManager audioManager;
    public float playerSound;
    public float groundSound;
    void Start()
    {
        source = GetComponent<AudioSource>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        DOTween.Init();
        Instantiated();
    }
    public void Instantiated()
    {
        transform.DOScale(1f, 0.5f).OnComplete<Tween>(Fall);
    }
    public void Fall()
    {
        transform.DOMoveY(-0.5f, duration).OnComplete<Tween>(TriggerEntered);
    }
    public void TriggerEntered()
    {
        transform.DOScale(0.1f, 0.5f).OnComplete<Tween>(DestroyDdong);
    }
    public void DestroyDdong()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        source.volume = audioManager.sfxVolume;
        if (other.CompareTag("Player"))
        {
            source.time = playerSound;
            source.SetScheduledEndTime(playerSound + 2.5f);
            source.Play();
        }
        else
        {
            source.time = groundSound;
            source.SetScheduledEndTime(groundSound + 2.5f);
            source.Play();
        }
    }

}
