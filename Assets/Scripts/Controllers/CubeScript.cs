using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    public float moveSpeed = 2f;

    public bool isCubeActive = false;

    public CubeType cubeType;

    private Color startcolor;

    private Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        startcolor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the cube if the cube is active
        if(isCubeActive)
        {
            //x,y,z = 0
            transform.rotation = Quaternion.identity;

            //x,y,z => y = 0f
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }
        
        // Setup highlight color if CUbe is active
        if(isCubeActive && renderer.material.color != Color.red)
        {
            renderer.material.color = Color.red;
        }
        else if(!isCubeActive && renderer.material.color != startcolor)
        {
            renderer.material.color = startcolor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Tigger to respawn the cube
        if(other.CompareTag("Respawn"))
        {
            // Ask the controller to spawn a similar cube
            GameManagerController.Instance.gameController.SpawnCube(this.gameObject);

            // Ask the controller to remove the current cube from instantiated prefabs
            GameManagerController.Instance.gameController.instatiatedPrefabs.Remove(this.gameObject);

            // Ask the controller to enable cube select mode
            GameManagerController.Instance.gameController.CursorVisible();

            // Ask the controller to increment the score
            GameManagerController.Instance.gameController.IncrementScore();

            // Destro this gameobject
            Destroy(this.gameObject);
        }
    }

    // On selection of the object by the cursor
    void OnMouseDown()
    {
        
        if(Cursor.visible)
        {   
            // Ask controller to enable cube active mode
            GameManagerController.Instance.gameController.CursorInVisible();

            // Mark all other cubes as inactive and the selected one as active
            try{
                foreach(var obj in GameManagerController.Instance.gameController.instatiatedPrefabs)
                {
                    if(obj != this.gameObject)
                    {
                        obj.GetComponent<CubeScript>().isCubeActive = false;
                    }
                    else
                    {
                        obj.GetComponent<CubeScript>().isCubeActive = true;
                    }
                }
            }
            catch{}
        } 
    }
}
