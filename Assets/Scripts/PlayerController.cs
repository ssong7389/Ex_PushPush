using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;

    public GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckOthers(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckOthers(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckOthers(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckOthers(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.Retry();
        }
    }

    public void CheckOthers(Vector3 dir)
    {
        // TransformDirection
        if (Physics.Raycast(transform.position, transform.TransformDirection(dir), out hit, 1f)) 
        {
            Transform tr = hit.collider.transform;
            //Debug.Log(tr.gameObject.tag);
            switch (hit.collider.tag)
            {
                case "Ball":
                    Debug.Log(tr.gameObject.tag);
                    if(Physics.Raycast(tr.position, tr.TransformDirection(dir), out hit2, 1f))
                    {
                        switch (hit2.collider.tag)
                        {
                            case "Bucket":
                                transform.Translate(dir);
                                tr.Translate(dir);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        transform.Translate(dir);
                        tr.Translate(dir);
                        gm.CheckBallPosition();
                    }
                    break;
                case "Wall":
                    Debug.Log(tr.gameObject.tag);
                    break;
                //case "Bucket":
                //    transform.Translate(dir);
                //    break;
                default:
                    break;
            }
        }
        else
        {
            transform.Translate(dir);
        }
    }
}
