using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example_DoTween_Move : MonoBehaviour
{
    void Start()
    {
        // 초기화로 시작
        DOTween.Init();
        // snapping - 값 int 로
        transform.DOMoveX(8f, 2f);
    }

    public void MoveRight()
    {
        transform.DOMoveX(8f, 2f);
    }
    public void MoveLeft()
    {
        transform.DOMoveX(-8f, 2f);
    }

    public void RotateRight()
    {
        transform.DORotate(new Vector3(0, -270, 0), 1f, RotateMode.Fast);
    }

    public void RotateLeft()
    {
        transform.DORotate(new Vector3(0, 270, 0), 1f, RotateMode.Fast);
    }
}
