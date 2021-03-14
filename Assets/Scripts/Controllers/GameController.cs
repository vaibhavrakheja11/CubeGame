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
        // Set Cursor to be visible
        CursorVisible();

        // Spawn cube on start
        if(spawnLocations != null)
        {
            foreach(var obj in cubePrefabs)
            {
                SpawnCube(obj,0f);
            }
        }
        
    }

    // Set Cursor to be Visible
    public void CursorVisible()
    {
        
        Cursor.visible = true;
    }

    // Set Cursor to be Invisble
    public void CursorInVisible()
    {
        Cursor.visible = false;
    }

    // Spawn the cube at it sepcified location
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
        // Get Escape Input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(var obj in instatiatedPrefabs)
            {
                obj.GetComponent<CubeScript>().isCubeActive = false;
            }
            CursorVisible();
        }

        // Get 'M' Input
        if (Input.GetKeyDown(KeyCode.M))
        {
            GoGokuMode(!GoGoku);
        }
    }

    // SPawn objects after 7 seconds
    IEnumerator SpawnObject(GameObject obj, Transform loaction, float duration = 7f)
    {
        yield return new WaitForSeconds(duration);
        var tempObj = Instantiate(obj, loaction.position, Quaternion.identity);
        instatiatedPrefabs.Add(tempObj);
    }

    // Increment the score
    public void IncrementScore()
    {
        m_score++;
        IncreaseScore.Invoke(m_score.ToString());
    }

    // Enable or Disable mode to select all cubes
    void GoGokuMode(bool goGoku)
    {
        // change bool value
        GoGoku = goGoku;

        if(goGoku)
        {
            // Mark all cubes as Active
            foreach(var obj in instatiatedPrefabs)
            {
                obj.GetComponent<CubeScript>().isCubeActive = true;
                CursorInVisible();
            }
        }
        else
        {
            // Mark All cubes as inactive
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
