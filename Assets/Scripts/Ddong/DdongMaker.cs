using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DdongMaker : MonoBehaviour
{
    public GameObject ddongPrefab;
    public DdongManager dm;
    public float coolTime = 0;
    public int x = 0;
    Vector3 originPos;
    void Start()
    {
        originPos = transform.position;
        StartCoroutine(MakeDdong());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MakeDdong()
    {
        yield return new WaitForSeconds(dm.startCountDown + 1);

        while (!dm.isGameOver)
        {
            x = Random.Range(-3, 4);
            transform.position += new Vector3(x, 0, 0);
            Instantiate(ddongPrefab, transform.position, transform.rotation);
            coolTime = Random.Range(0.55f, 1f);
            yield return new WaitForSeconds(coolTime);
            transform.position = originPos;
        }
    }
}
