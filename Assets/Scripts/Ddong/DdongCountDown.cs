using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DdongCountDown : MonoBehaviour
{
    public DdongManager dm;
    public Text countDownText;
    int countDown;
    AudioManager audioManager;
    void Start()
    {
        countDown = dm.startCountDown;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        StartCoroutine(CountDown());
        //countDownText.DOCounter(dm.startCountDown, 1, 5f);
    }

    IEnumerator CountDown()
    {
        audioManager.Beep();
        while (countDown > 0)
        {
            countDownText.text = countDown.ToString();
            countDown--;
            transform.DOScale(1f, 1f).OnComplete<Tween>(OriginScale);
            audioManager.Beep();
            yield return new WaitForSeconds(1);
        }
        transform.DOScale(1f, 1f);
        countDownText.text = "START!";
        countDownText.DOFade(0, 1f);


    }
    public void OriginScale()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void GameStarted()
    {
        gameObject.SetActive(false);
    }
}
