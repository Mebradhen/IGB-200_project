using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableBlocks : MonoBehaviour
{
    public float timeSpent;
    public float timeSubtraction;
    public float timeActive = 0f;
    public float timeNotActive = 0f;
    public GameObject gameObjects;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = GameObject.FindGameObjectWithTag("removable");        
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            timeActive = Time.time;
        }

        if (active == false)
        {
            timeNotActive = Time.time;
        }


        if (Time.time - timeNotActive >= 2f)
        {
            gameObjects.SetActive(false);
            active = false;
        }

        if (Time.time - timeActive >= 2f)
        {
            gameObjects.SetActive(true);
            active = true;
        }
    }
}
