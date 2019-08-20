using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour

{
    public float downTime, upTime = 0;    
    public bool ready = false;
    private bool moving = false;
    public float timeCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

        Jump();
        if (moving == true)
        {            
            transform.position += Vector3.up/6;
        }
    }

    void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space) && (downTime - timeCheck) > 0)
        {
            moving = true;
        }

        if (Input.GetKey(KeyCode.Space) && moving != true)
        {            
            downTime = Time.time;         
            
        }
        else if (moving != true)
        {
            timeCheck = Time.time;
        }
                
    }

    void OnTriggerEnter2D(Collider2D other)
    
    {        
        if (other.gameObject.tag == "Level1" && ((downTime - timeCheck) >= 0 && (downTime - timeCheck) < 1))
        {
            moving = false;
        }

        if (other.gameObject.tag == "Level2" && ((downTime - timeCheck) >= 1 && (downTime - timeCheck) < 2))
        {
            moving = false;
        }

        if (other.gameObject.tag == "Level3" && ((downTime - timeCheck) >= 2))
        {
            moving = false;
        }
    }
}
