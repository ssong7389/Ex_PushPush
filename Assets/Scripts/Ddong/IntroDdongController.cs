using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IntroDdongController : MonoBehaviour
{
    Vector3 originPos;
    void Start()
    {
        DOTween.Init();
        originPos = transform.position;
        transform.DOMoveY(-0.5f, 1.5f + originPos.y/8);
    }
    private void OnTriggerEnter(Collider other)
    {
        transform.DOScale(0.1f, 1f).OnComplete<Tween>(Fall);
    }
    void Fall()
    {
        transform.position = originPos;
        transform.localScale = Vector3.one;
        transform.DOMoveY(-0.5f, Random.Range(1f, 3f));
    }
}
