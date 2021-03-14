using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> cubePrefabs = new List<GameObject>();

    public List<GameObject> instatiatedPrefabs = new List<GameObject>();

    public List<GameObject> spawnLocations = new List<GameObject>();

    public static event Action<string> IncreaseScore;

    int m_score = 0;

    public Camera camera;

    bool GoGoku = false;

    const string UIScene = "UIScene";


    // Start is called before the first frame update
    void Start()
    {
        CursorVisible();
        int i = 0;
        if(spawnLocations != null)
        {
            foreach(var obj in cubePrefabs)
            {
                SpawnCube(obj,0f);
            }

        }
        
    }

    public void CursorVisible()
    {
        
        Cursor.visible = true;
    }

    public void CursorInVisible()
    {
        Cursor.visible = false;
    }

    void FindObject()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            Debug.Log(hit.collider.gameObject.name);
            
            // Do something with the object that was hit by the raycast.
        }
    }

    public void SpawnCube(GameObject obj, float duration = 7f)
    {
       
        switch(obj.GetComponent<CubeScript>().cubeType)
        {
            case CubeType.Black:
                StartCoroutine(SpawnObject(cubePrefabs[0], spawnLocations[3].transform, duration));
                break;
            case CubeType.Green:
                StartCoroutine(SpawnObject(cubePrefabs[2], spawnLocations[2].transform, duration));
                break;
            case CubeType.Blue:
                StartCoroutine(SpawnObject(cubePrefabs[1], spawnLocations[1].transform, duration));
                break;
            case CubeType.Yellow:
                StartCoroutine(SpawnObject(cubePrefabs[3], spawnLocations[0].transform, duration));
                break;
        }        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(var obj in instatiatedPrefabs)
            {
                obj.GetComponent<CubeScript>().isCubeActive = false;
            }
            CursorVisible();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            GoGokuMode(!GoGoku);
        }
    }

    IEnumerator SpawnObject(GameObject obj, Transform loaction, float duration = 7f)
    {
        yield return new WaitForSeconds(duration);
        var tempObj = Instantiate(obj, loaction.position, Quaternion.identity);
        instatiatedPrefabs.Add(tempObj);
    }

    public void IncrementScore()
    {
        m_score++;
        IncreaseScore.Invoke(m_score.ToString());
    }

    void GoGokuMode(bool goGoku)
    {
        GoGoku = goGoku;
        if(goGoku)
        {
            foreach(var obj in instatiatedPrefabs)
            {
                obj.GetComponent<CubeScript>().isCubeActive = true;
                CursorInVisible();
            }
        }
        else
        {
            foreach(var obj in instatiatedPrefabs)
            {
                obj.GetComponent<CubeScript>().isCubeActive = false;
                CursorVisible();
            }
        }
        
    }
}



public enum CubeType{
    Yellow,
    Green,
    Blue,
    Black
}
