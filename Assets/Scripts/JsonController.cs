using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonController : MonoBehaviour
{
    public Canvas InfoCanvas;
    public string info;

    public class Mineral
    { 
    
    }

    public class Crystal
    {

    }

    // Start is called before the first frame update
    void Start()
    {


        //Find the object you're looking for
        GameObject tempObject = GameObject.Find("Info");
        if (tempObject != null)
        {
            //If we found the object , get the Canvas component from it.
            InfoCanvas = tempObject.GetComponent<Canvas>();
            if (InfoCanvas == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
