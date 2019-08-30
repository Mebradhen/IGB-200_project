using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_camera : MonoBehaviour
{
    private float x;
    private float y = 0.0f;
    private float distance_speed = 0.0f;
    private Vector3 rotateValue, positionValue;
    private float timer_start = 0.0f;

    public int Stage_menu = 1;


     void Update()
    {

        switch (Stage_menu)
        {
            case 1:
                intro();
                break;

            case 2:
                menu();
                break;
        }  
    }

    void intro()
    {
        if (timer_start > 20.0f)
        {
            if (transform.rotation.y > 0.05f)
            {

                distance_speed = (transform.rotation.y / 55) * 4000;

                rotateValue = new Vector3(x, y + distance_speed * Time.deltaTime, 0);

                transform.eulerAngles = transform.eulerAngles - rotateValue;
            }
            else
            {
                Enter_menu();
            }

        }
        else
        {
            timer_start += 15 * Time.deltaTime;
        }
    }


    void menu()
    {


        if(transform.position.y > -20.0f)
        {
            
            distance_speed = distance_speed - 5 * Time.deltaTime;
   
            transform.position = new Vector3(0.0f, 87.12735f - distance_speed * distance_speed, 0.0f);

        }
        else
        {

        }
    }


        void Enter_menu()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (Stage_menu)
            {
                case 1:
                    Stage_menu = 2;
                    break;

                case 2:
                    Stage_menu = 3;
                    break;
            }
            timer_start = 0.0f;
            distance_speed = 0.0f;
        }
    }
}
