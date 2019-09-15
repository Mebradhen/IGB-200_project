using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBar : MonoBehaviour
{
    private Transform bar;
    public Vector2 movementVector;
    float jumpMeter = 0f;    
    // Start is called before the first frame update
    void Start()
    {        
        bar = transform.Find("Bar");               
    }

    // Update is called once per frame
    void Update()
    {       
        movementVector.y = Input.GetAxis("Vertical");

        if (movementVector.y <= -0.9)
        {            
            jumpMeter += 0.01f;
            SetSize(jumpMeter);
            if(jumpMeter > 1)
            {
                jumpMeter = 1;
                SetSize(jumpMeter);
            }
        }
        else
        {
            jumpMeter = 0f;
            SetSize(jumpMeter);
        }
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(1f, size);
    }
}
