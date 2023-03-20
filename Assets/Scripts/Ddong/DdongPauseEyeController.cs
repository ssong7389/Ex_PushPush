using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DdongPauseEyeController : MonoBehaviour
{
    public Transform left, right;
    void Start()
    {
        DOTween.Init();
    }

    private void OnEnable()
    {
        left.DOScaleY(1f, 2f).SetUpdate(true);
        right.DOScaleY(1f, 2f).SetUpdate(true);
    }

    private void OnDisable()
    {
        left.DOScaleY(0.1f, 1f);
        right.DOScaleY(0.1f, 1f);
    }
}
