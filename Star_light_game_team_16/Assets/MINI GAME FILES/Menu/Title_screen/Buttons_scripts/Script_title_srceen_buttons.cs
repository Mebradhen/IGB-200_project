using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_title_srceen_buttons : MonoBehaviour
{

    bool timerActive;
    [SerializeField]
    float timer = 2;

    [SerializeField]
    string sceneName;

    [SerializeField]
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {         

                if (this.name == "start")
                {
                        Start_menu_move();
                }

                if (this.name == "options")
                {
                        option_menu_move();
                }

                if (this.name == "reset")
                {
                         reset_menu_move();
                }

                if (this.name == "yes")
                {
                        Reset_game_yes();
                }
                if (this.name == "No")
                {
                        Reset_game_no();
                }
                if (this.name == "back")
                {
                        Controls_game_back();
                }           
        }
    }

    private void OnMouseOver()
    {
        this.GetComponent<Animator>().SetBool("Title_screen_hover", true);
    }

    private void OnMouseExit()
    {
        this.GetComponent<Animator>().SetBool("Title_screen_hover", false);
    }

    private void OnMouseDown()
    {

        timerActive = true;
    }

    private void Start_menu_move()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_2", true);

        timer -= Time.deltaTime;

        if (timer < 0)
        {

            SceneManager.LoadScene(sceneName);
        }
    }


    private void option_menu_move()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_3", true);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 2.0f;
            timerActive = false;
        }
    }

    private void reset_menu_move()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_4", true);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = 2.0f;
            timerActive = false;
        }
    }


    private void Reset_game_yes()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_4", false);

        //RESET CODE HERE!!
        timer = 2.0f;
        timerActive = false;
    }

    private void Reset_game_no()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_4", false);

        timer = 2.0f;
        timerActive = false;
    }

    private void Controls_game_back()
    {
        camera.GetComponent<Animator>().SetBool("Tile_screen_intro_move_3", false);

        timer = 2.0f;
        timerActive = false;
    }


}
