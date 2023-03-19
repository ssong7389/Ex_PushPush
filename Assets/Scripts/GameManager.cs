using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] buckets;
    public GameObject[] balls;
    public int curCnt = 0;
    public int maxCnt = 0;
    public int correctCnt;
    public int inCorrectCnt;
    public int curLv = 1;
    public int maxLv = 10;
    public MapGenerator mapGenerator;
    public Text scoreText;
    public Text stageText;

    public void SetBucketsAndBalls()
    {
        StartCoroutine(FindBucketsAndBalls());
    }

    IEnumerator FindBucketsAndBalls()
    {
        yield return buckets = new GameObject[GameObject.FindGameObjectsWithTag("Bucket").Length];
        yield return balls = new GameObject[GameObject.FindGameObjectsWithTag("Ball").Length];

        buckets = GameObject.FindGameObjectsWithTag("Bucket");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        curCnt = 0;
        maxCnt = balls.Length;

        //scoreText.text = $"{curCnt} / {maxCnt}";
        //stageText.text = $"STAGE: {curLv}";

        //Debug.Log($"max : {maxCnt}");
    }

    public void CheckBallPosition()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            for (int j = 0; j < balls.Length; j++)
            {
                //Debug.Log(Vector3.Distance(buckets[i].transform.position, balls[j].transform.position));
                if(Vector3.Distance(buckets[i].transform.position,balls[j].transform.position)<0.2f)
                {
                    correctCnt++;
                    curCnt = correctCnt;
                }
            }
        }
        //Debug.Log(curCnt);
        correctCnt = 0;
        //scoreText.text = $"{curCnt}/ {maxCnt}";
        if(curCnt == maxCnt)
        {
            Debug.Log("Stage Clear");
            curLv++;
            curCnt = 0;
            maxCnt = 0;
            if(curLv != maxLv)
            {
                mapGenerator.DestroyMap(curLv);
            }
            else
            {
                Debug.Log("All Clear");
            }
        }
    }
    public void Retry()
    {
        mapGenerator.DestroyMap(curLv);
    }
}

