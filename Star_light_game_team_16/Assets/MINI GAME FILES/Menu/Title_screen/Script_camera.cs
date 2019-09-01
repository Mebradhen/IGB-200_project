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

    [SerializeField]
    Animator[] animators;

    [SerializeField]
    GameObject The_logo_intro;

    [SerializeField]
    GameObject The_button_intro;

    [SerializeField]
    GameObject The_options_intro;

    public int Stage_menu = 1;

    void Start()
    {


    }

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
            this.GetComponent<Animator>().SetBool("Title_screen_intro_move_0", true);


            if (transform.rotation.y < 0.25f)
            {
                The_logo_intro.GetComponent<Animator>().SetBool("Logo_menu_bool", true);
            }

            if (transform.rotation.y < 0.15f)
            {
                The_button_intro.GetComponent<Animator>().SetBool("Button_show_menu", true);

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
        this.GetComponent<Animator>().SetBool("Title_screen_intro_move_1", true);
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



    public void camera_start_game()
    {
        this.GetComponent<Animator>().SetBool("Title_screen_intro_move_2", true);
    }
}
