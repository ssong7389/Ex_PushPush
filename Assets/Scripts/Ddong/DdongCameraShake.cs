using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DdongCameraShake : MonoBehaviour
{    
    void Start()
    {
        DOTween.Init();       
    }

    public void ShakeCamera()
    {
        transform.DOShakePosition(1f).OnComplete<Tween>(SetOriginPos);
    }
    void SetOriginPos()
    {
        transform.SetLocalPositionAndRotation(new Vector3(0, 3f, -11f), Quaternion.Euler(0, 0, 0));
    }
}
