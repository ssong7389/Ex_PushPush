using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] mapObjectPrefab;
    public string dataPath;
    public List<Dictionary<string, object>> data;
    GameManager gm;
    void Start()
    {
        LoadMapData(1);

        //for (int i = 0; i < 12; i++)
        //{
        //    for (int j = 0; j < 12; j++)
        //    {
        //        GameObject ground = Instantiate(mapObjectPrefab[0]) as GameObject;
        //        ground.name = ground.tag + "(" + j + ", " + i + ")";
        //        ground.transform.parent = GameObject.Find("Ground12x12").transform;
        //        ground.transform.localPosition = new Vector3(j, 0, -i);
        //    }
        //}
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        MakeMap();
    }

    public void MakeMap()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                int dataSet = (int)data[i][j.ToString()];
                if (dataSet != 0)
                {
                    GameObject ground = Instantiate(mapObjectPrefab[5]);
                    ground.name = $"{ground.tag}({i},{j})";
                    ground.transform.parent = GameObject.Find("Map12x12").transform;
                    ground.transform.localPosition = new Vector3(j, -1f, -i);

                    if (dataSet != 5)
                    {
                        GameObject mapObj = Instantiate(mapObjectPrefab[dataSet]);

                        switch (mapObj.tag)
                        {
                            case "Wall":
                                mapObj.name = $"{mapObj.tag}({i},{j})";
                                mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                                mapObj.transform.localPosition = new Vector3(j, 0, -i);
                                break;
                            case "Bucket":
                                mapObj.name = $"{mapObj.tag}({i},{j})";
                                mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                                mapObj.transform.localPosition = new Vector3(j, 0.25f, -i);
                                break;
                            case "Ball":
                                mapObj.name = $"{mapObj.tag}({i},{j})";
                                mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                                mapObj.transform.localPosition = new Vector3(j, 0.25f, -i);
                                break;
                            case "Player":
                                mapObj.name = $"{mapObj.tag}({i},{j})";
                                mapObj.transform.parent = GameObject.Find("Map12x12").transform;
                                mapObj.transform.localPosition = new Vector3(j, 0.25f, -i);
                                break;
                        }
                    }
                }
            }
        }
        gm.SetBucketsAndBalls();
    }
    public void LoadMapData(int stage)
    {
        dataPath = $"MapData/Lv{stage}";
        data = CSVReader.Read(dataPath);

    }
    public void DestroyMap(int lv)
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] buckets = GameObject.FindGameObjectsWithTag("Bucket");
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] innerGrounds = GameObject.FindGameObjectsWithTag("InnerGround");

        for (int i = 0; i < walls.Length; i++)
        {
            Destroy(walls[i]);
        }
        for (int i = 0; i < buckets.Length; i++)
        {
            Destroy(buckets[i]);
        }
        for (int i = 0; i < balls.Length; i++)
        {
            Destroy(balls[i]);
        }
        for (int i = 0; i < innerGrounds.Length; i++)
        {
            Destroy(innerGrounds[i]);
        }
        Destroy(player);
        LoadMapData(lv);
        MakeMap();
    }
}
