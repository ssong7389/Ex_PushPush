using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DdongPlayerController : MonoBehaviour
{
    public float distance;
    public float duration;

    public Button leftBtn;
    public Button rightBtn;

    public int hp = 0;
    public int maxHp = 100;
    public Transform hudTransform;
    public RectTransform canvas;
    public RectTransform hpBar;
    public bool damaged = false;
    Slider hpSlider;
    Camera main;

    public DdongManager dm;
    Animator anim;
    public GameObject eyes;
    GameObject leftEye, rightEye;
    void Start()
    {
        DOTween.Init();
        hudTransform = transform.Find("HudTr");
        main = Camera.main;
        hp = maxHp;
        hpSlider = hpBar.GetComponent<Slider>();
        hpSlider.value = 1f;
        anim = GetComponentInChildren<Animator>();
        leftEye = eyes.transform.Find("left").gameObject;
        rightEye = eyes.transform.Find("right").gameObject;
    }

    private void Update()
    {
        if (!damaged)
        {
            Vector3 curPos = hudTransform.transform.position;
            Vector2 screenPoint = main.WorldToScreenPoint(curPos);
            Vector2 canvasPos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, Camera.main, out canvasPos);
            hpBar.localPosition = canvasPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ddong"))
        {
            damaged = true;
            hp -= 20;
            main.GetComponent<DdongCameraShake>().ShakeCamera();
            other.gameObject.GetComponent<DdongController>().TriggerEntered();
            hpSlider.DOValue((float)hp / maxHp, 1f).OnComplete<Tween>(()=>damaged=false);
            //hpSlider.value = (float)hp / maxHp;
            if (hp <= 0)
            {
                dm.IsGameOver = true;
                Dead();
            }
        }
    }
    public void MoveLeft()
    {
        if (transform.position.x > -3)
        {
            DeactivateBtns();
            transform.DOMoveX(transform.position.x - distance, duration).OnComplete<Tween>(ActivateBtns);
        }
    }
    public void MoveRight()
    {
        if (transform.position.x < 3)
        {
            DeactivateBtns();
            transform.DOMoveX(transform.position.x + distance, duration).OnComplete<Tween>(ActivateBtns);
        }
    }

    void ActivateBtns()
    {
        leftBtn.interactable = true;
        rightBtn.interactable = true;
    }
    void DeactivateBtns()
    {
        leftBtn.interactable = false;
        rightBtn.interactable = false;
    }

    void Dead()
    {
        dm.audioManager.Dead();
        leftBtn.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        anim.enabled = false;
        hpBar.gameObject.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
       
        transform.DORotate(new Vector3(0, 0, 90), 2f).OnComplete<Tween>(CameraMove);
    }
    void CameraMove()
    {
        dm.audioManager.Lose();
        main.transform.DOMove(new Vector3(transform.position.x-0.5f, 0, -3f), 2f).OnComplete<Tween>(CloseEye);
    }
    void CloseEye()
    {
        leftEye.transform.DOScaleY(0.01f, 2f);
        rightEye.transform.DOScaleY(0.01f, 2f).OnComplete<Tween>(dm.PlayGameOver);
    }
}
