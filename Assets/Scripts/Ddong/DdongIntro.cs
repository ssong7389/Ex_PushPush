using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DdongIntro : MonoBehaviour
{
    public Text title;
    public Text[] dodge;
    public GameObject popup;

    void Start()
    {
        DOTween.Init();
        title.rectTransform.DOMoveX(240, 1f).OnComplete<Tween>(DodgeText);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            popup.transform.DOMoveY(360, 2f);
        }
    }
    void DodgeText()
    {
        for (int i = 0; i < dodge.Length; i++)
        {
            dodge[i].transform.DOMoveY(600f, 2f);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
