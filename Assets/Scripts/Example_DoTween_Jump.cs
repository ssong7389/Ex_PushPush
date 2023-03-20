using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Example_DoTween_Jump : MonoBehaviour
{
    public Button btn;
    void Start()
    {
        DOTween.Init();
    }

    public void Jump()
    {
        btn.interactable = false;
        transform.DOLocalJump(transform.position, 5f, 1, 1f, false).OnComplete<Tween>(Grounded);
    }
    void Grounded()
    {
        transform.position = Vector3.zero;
        btn.interactable = true;
    }
}
