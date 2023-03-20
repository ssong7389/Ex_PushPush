using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DdongController : MonoBehaviour
{
    public float duration;
    void Start()
    {
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
}
