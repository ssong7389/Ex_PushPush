using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DdongManager : MonoBehaviour
{
    public int score = 0;
    public int startCountDown = 5;
    public bool isGameOver = false;

    public GameObject pausePopup;
    public Button pause;
    public Button pauseYes;
    public Button pauseNo;
    void Start()
    {
        pauseNo.onClick.AddListener(() => Cancel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);
    }

    public void Cancel()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);
    }
}
