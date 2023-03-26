using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DdongManager : MonoBehaviour
{
    public int score = 0;
    public int startCountDown = 5;
    public bool isGameOver = false;
    public Text finalScore;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                pause.gameObject.SetActive(false);
            }
        }
    }
    public GameObject gameOver;
    public GameObject pausePopup;
    public GameObject ground;

    public Button pause;
    public Button pauseYes;
    public Button pauseNo;

    public Text scoreTitle;
    public Text scoreText;
    public Button leftBtn;
    public Button rightBtn;

    public Slider bgmSlider;
    public Slider sfxSlider;


    public GameObject gameStart;
    public Camera main;
    Vector3 camPos = new Vector3(0, 3, -11);

    public AudioManager audioManager;
    public Image bgmImage;
    public Image sfxImage;

    void Awake()
    {
        pause.gameObject.SetActive(false);
        leftBtn.gameObject.SetActive(false);
        rightBtn.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        scoreTitle.gameObject.SetActive(false);
        pauseNo.onClick.AddListener(() => Cancel());
        main = Camera.main;
        DOTween.Init();


    }
    private void Start()
    {
        gameStart.transform.DOLocalMoveY(-1380, 2f).OnComplete<Tween>(StartCamMove);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void StartCamMove()
    {
        gameStart.gameObject.SetActive(false);
        main.transform.DOMove(camPos, 5f).OnComplete<Tween>(()=>ActiveUI());
        main.DOFieldOfView(60, 5f);
    }
    void ActiveUI()
    {
        pause.gameObject.SetActive(true);
        leftBtn.gameObject.SetActive(true);
        rightBtn.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreTitle.gameObject.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
    }
    public void Intro()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Cancel()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
    }

    public void PlayGameOver()
    {
        ground.GetComponent<BoxCollider>().enabled = false;
        finalScore.text = score.ToString();
        gameOver.SetActive(true);
        gameOver.transform.DOLocalRotate(new Vector3(0, 0, 0), 2f);
        gameOver.transform.DOLocalMoveY(0, 2f);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
