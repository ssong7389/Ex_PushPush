using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DdongGroundController : MonoBehaviour
{
    public Text scoreText;
    public DdongManager dm;

    void Start()
    {
        DOTween.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ddong"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            dm.score++;
            scoreText.text = $"{dm.score.ToString("0000")}";
            scoreText.transform.DOScale(1.5f, 0.4f).OnComplete<Tween>(() => scoreText.transform.localScale = Vector3.one);
        }
    }
}
