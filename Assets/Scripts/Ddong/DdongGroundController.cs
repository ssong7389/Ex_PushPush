using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DdongGroundController : MonoBehaviour
{
    public Text scoreText;
    public DdongManager dm;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ddong"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            dm.score++;
            scoreText.text = $"SCORE : {dm.score.ToString("0000")}";
        }
    }
}
