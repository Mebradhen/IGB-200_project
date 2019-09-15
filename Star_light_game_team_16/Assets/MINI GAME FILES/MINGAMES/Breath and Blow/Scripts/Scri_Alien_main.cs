using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scri_Alien_main : MonoBehaviour
{

    private GameObject Alien_eyes_1, Alien_eyes_2, Alien_mouth_1, Alien_mouth_2;

    private bool eyes_1, eyes_2, mouth_1, mouth_2;

    public float Breath_grow = 0.0f;

    public bool blow = false;

    private float eye_blink = 0.0f;

    private Vector3 OG_scale;

    private Vector3 OG_scale_save;

    private GameObject gameController, Game_clover_stalks;

    public int clover_count = 0;

    // Start is called before the first frame update
    void Start()
    {

        gameController = GameObject.FindGameObjectWithTag("GameController");


        OG_scale = transform.localScale;
        OG_scale_save = transform.localScale;

        Alien_eyes_1 = this.transform.Find("alien_eyes_1").gameObject;
        Alien_eyes_2 = this.transform.Find("alien_eyes_2").gameObject;
        Alien_mouth_1 = this.transform.Find("alien_mouth").gameObject;
        Alien_mouth_2 = this.transform.Find("alien_mouth_2").gameObject;

        eyes_1 = true;
        eyes_2 = false;
        mouth_1 = false;
        mouth_2 = false;
    }

    // Update is called once per frame
    void Update()
    {

        Control_blink();

        Control_blow();

        Control_face();

        CLover_total();
    }


    private void Control_blink()
    {
        eye_blink += 10.0f * Time.deltaTime;

        if (eye_blink > 30.0f)
        {
            eyes_1 = false;
            eyes_2 = true;

            if (eye_blink > 31.0f)
            {
                eyes_1 = true;
                eyes_2 = false;
                eye_blink = 0.0f;
            }
        }
    }


    private void Control_blow()
    {

        float Controller_paddles_1 = Input.GetAxis("Controller_paddles_1");
        float Controller_paddles_2 = Input.GetAxis("Controller_paddles_2");

        float Alien_scale_rate = 0.0f;

        if(Controller_paddles_1 == 1.0f)
        {
            Breath_grow += 5.0f * Time.deltaTime;
            mouth_1 = true;
            mouth_2 = false;
            blow = false;
            Alien_scale_rate = 0.1f;
        }
        else if (Controller_paddles_2 == 1.0f && Breath_grow > 1.0f)
        {
            eyes_1 = false;
            eyes_2 = true;
            blow = true;
            eye_blink = 40.0f;

            Breath_grow -= 17.0f * Time.deltaTime;

            mouth_1 = false;
            mouth_2 = true;
            Alien_scale_rate = -0.7f;
        }
        else
        {
            Breath_grow -= 3.0f * Time.deltaTime;
            mouth_1 = false;
            mouth_2 = false;
            blow = false;
            Alien_scale_rate = -0.07f;
        }

        if(Breath_grow < 0.0f)
        {
            Breath_grow = 0.0f;
        }

        OG_scale.x += Alien_scale_rate * Time.deltaTime;
        OG_scale.y += Alien_scale_rate * Time.deltaTime;

        if(OG_scale.x < OG_scale_save.x)
        {
            OG_scale = OG_scale_save;         
        }

        if (OG_scale.x < 1.0f)
        {
            transform.localScale = OG_scale;
        }
        else
        {
            Breath_grow = 15.0f;
        }
    }

    private void Control_face()
        {
            Alien_eyes_1.SetActive(eyes_1);
            Alien_eyes_2.SetActive(eyes_2);
            Alien_mouth_1.SetActive(mouth_1);
            Alien_mouth_2.SetActive(mouth_2);
        }

        private void CLover_total()
        {
            EventController EC = gameController.GetComponent<EventController>();
            if (clover_count >= GameObject.FindGameObjectsWithTag("clover_stalks").Length)
            {
                EC.miniGame_Ended = true;
            }

        }
        

    }


