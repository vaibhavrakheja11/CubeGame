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
        if(isCubeActive)
        {
            //x,y,z = 0
            transform.rotation = Quaternion.identity;

            //x,y,z => y = 0f
            transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }

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
        if(other.CompareTag("Respawn"))
        {
            GameManagerController.Instance.gameController.SpawnCube(this.gameObject);
            GameManagerController.Instance.gameController.instatiatedPrefabs.Remove(this.gameObject);
            GameManagerController.Instance.gameController.CursorVisible();
            GameManagerController.Instance.gameController.IncrementScore();
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown()
    {
        
        if(Cursor.visible)
        {   
            GameManagerController.Instance.gameController.CursorInVisible();

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
            catch
            {

            }
            
        } 
    }
}
