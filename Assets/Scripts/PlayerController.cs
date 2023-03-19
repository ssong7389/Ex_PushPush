using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;

    public GameManager gm;

    Animator anim;
    public float moveTime = 0.5f;
    public bool isMoving = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.localRotation = Quaternion.Euler(0, -90f, 0);
                CheckOthers(Vector3.left); // -90 , -1 0 0
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.localRotation = Quaternion.Euler(0, 90f, 0);
                CheckOthers(Vector3.right); // 90 , 1 0 0
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                CheckOthers(Vector3.forward); // 0 , 0 0 1
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.localRotation = Quaternion.Euler(0, 180f, 0);
                CheckOthers(Vector3.back); // 180, 0 0 -1
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.Retry();
        }
    }

    public void CheckOthers(Vector3 dir)
    {
        // TransformDirection
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f)) 
        {
            Transform tr = hit.collider.transform;
            switch (hit.collider.tag)
            {
                case "Ball":
                    //Debug.Log(tr.gameObject.tag);
                    if(Physics.Raycast(tr.position, tr.TransformDirection(dir), out hit2, 1f))
                    {
                        switch (hit2.collider.tag)
                        {
                            case "Bucket":
                                StartCoroutine(Push(hit.collider.gameObject, dir));
                                //transform.Translate(Vector3.forward);
                                //tr.Translate(dir);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //transform.Translate(Vector3.forward);
                        //tr.Translate(dir);
                        StartCoroutine(Push(hit.collider.gameObject, dir));

                    }
                    break;
                case "Wall":
                    //Debug.Log(tr.gameObject.tag);
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
            //transform.Translate(Vector3.forward);
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        //anim.SetInteger("Walk", 1);
        anim.SetBool("jump", true);

        float timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            transform.Translate(Vector3.forward * Time.deltaTime*2f);
            yield return new WaitForFixedUpdate();
        }
        isMoving = false;
        anim.SetBool("jump", false);

        //anim.SetInteger("Walk", 0);
    }

    IEnumerator Push(GameObject ball, Vector3 ballDir)
    {
        isMoving = true;
        anim.SetBool("jump", true);
        float timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            ball.transform.Translate(ballDir * Time.deltaTime * 2f);
            transform.Translate(Vector3.forward * Time.deltaTime * 2f);
            yield return new WaitForFixedUpdate();
        }
        isMoving = false;
        anim.SetBool("jump", false);
        gm.CheckBallPosition();
    }
}
