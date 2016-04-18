using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class roadGenerator : MonoBehaviour
{

    public GameObject Road;
    public GameObject Sword;
    public GameObject _camera;
    public List<GameObject> Clouds;
    public List<GameObject> Obstacles;
    List<GameObject> RoadListActive;
    List<GameObject> RoadListPassive;
    List<GameObject> CloudListActive;
    List<GameObject> CloudListPassive;
    public Material fireMAt;
    public Material earthMAt;
    public Material waterMAt;
    public Material windMAt;

    string Fire = "fire";
    string Earth = "earth";
    string Water = "water";
    string Wind = "wind";

    void Start()
    {
        RoadListActive = new List<GameObject>();
        RoadListPassive = new List<GameObject>();
        CloudListActive = new List<GameObject>();
        CloudListPassive = new List<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            CreateRoad();
        }
        for (int i = 0; i < 5; i++)
        {
            CreateClouds();
        }

    }
    void Generateobstacle()
    {
        GameObject _obstacle = Instantiate(Obstacles[Random.Range(0, Obstacles.Count)], new Vector3(_camera.transform.position.x, _camera.transform.position.y, _camera.transform.position.z + 10), Quaternion.identity) as GameObject;
    }
    void changeSword(string Type)
    {
        switch (Type)
        {
            case "fire":
                if (Sword.GetComponent<Renderer>().material != fireMAt)
                    Sword.GetComponent<Renderer>().material = fireMAt;
                break;
            case "earth":
                if (Sword.GetComponent<Renderer>().material != earthMAt)
                    Sword.GetComponent<Renderer>().material = earthMAt;
                break;
            case "water":
                if (Sword.GetComponent<Renderer>().material != waterMAt)
                    Sword.GetComponent<Renderer>().material = waterMAt;
                break;
            case "wind":
                if (Sword.GetComponent<Renderer>().material != windMAt)
                    Sword.GetComponent<Renderer>().material = windMAt;
                break;
        }
    }
    void chageSwordMAterial()
    {

    }
    void CreateRoad()
    {
        if (RoadListPassive.Count == 0)
        {
            GameObject myRoad;
            if (RoadListActive.Count != 0)
                myRoad = Instantiate(Road, new Vector3(0.1f, -0.03f, RoadListActive[RoadListActive.Count - 1].transform.position.z + 0.032f), Quaternion.identity) as GameObject;
            else
                myRoad = Instantiate(Road, new Vector3(0.1f, -0.03f, _camera.transform.position.z - 1), Quaternion.identity) as GameObject;
            RoadListActive.Add(myRoad);

            myRoad.transform.localScale = new Vector3(8, myRoad.transform.localScale.y, myRoad.transform.localScale.z);

        }
        else
        {
            RoadListPassive[0].transform.position = new Vector3(0.1f, -0.03f, RoadListActive[RoadListActive.Count - 1].transform.position.z + 0.032f);
            RoadListActive.Add(RoadListPassive[0]);
            RoadListPassive.Remove(RoadListPassive[0].gameObject);
        }
    }
    void CreateClouds()
    {
        if (CloudListPassive.Count == 0)
        {
            GameObject myCloud;
            if (CloudListActive.Count != 0)
                myCloud = Instantiate(Clouds[Random.Range(0, Clouds.Count)], new Vector3(Random.Range(1.1f, 1.5f), Random.Range(1.5f, 2.0f), CloudListActive[CloudListActive.Count - 1].transform.position.z + 5), Quaternion.identity) as GameObject;
            else
                myCloud = Instantiate(Clouds[Random.Range(0, Clouds.Count)], new Vector3(Random.Range(1.1f, 1.5f), Random.Range(1.5f, 2.0f), gameObject.transform.position.z - 5), Quaternion.identity) as GameObject;
            CloudListActive.Add(myCloud);
        }
        else
        {
            CloudListPassive[0].transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(1.1f, 1.5f), CloudListActive[CloudListActive.Count - 1].transform.position.z + 5);
            CloudListActive.Add(CloudListPassive[0]);
            CloudListPassive.Remove(CloudListPassive[0].gameObject);
        }
    }

    void Update()
    {
        //roadGenerator
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            changeSword(Fire);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            changeSword(Water);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            changeSword(Wind);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            changeSword(Earth);
        }

        if (RoadListActive[RoadListActive.Count - 1].transform.position.z < _camera.transform.position.z + 10)
        {
            CreateRoad();
        }
        if (RoadListActive[0].transform.position.z < _camera.transform.position.z - 0.1f)
        {
            RoadListPassive.Add(RoadListActive[0]);
            RoadListActive.Remove(RoadListActive[0].gameObject);
        }

        //cloudGenerator
        if (CloudListActive[CloudListActive.Count - 1].transform.position.z < _camera.transform.position.z + 3)
        {
            CreateClouds();
        }
        if (CloudListActive[0].transform.position.z < _camera.transform.position.z - 0.03f)
        {
            CloudListPassive.Add(CloudListActive[0]);
            CloudListActive.Remove(CloudListActive[0].gameObject);
        }
    }
}
