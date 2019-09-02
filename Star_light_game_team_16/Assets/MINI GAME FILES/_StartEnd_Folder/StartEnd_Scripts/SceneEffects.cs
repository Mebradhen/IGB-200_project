using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEffects : MonoBehaviour
{
    [SerializeField]
    GameObject miniGameController;

    public
    int star_Achived;
    float star_timer;

    [SerializeField]
    GameObject effect_Ready;
    [SerializeField]
    GameObject effect_Start;
    [SerializeField]
    GameObject effect_Great;
    [SerializeField]
    GameObject effect_Star1;
    [SerializeField]
    GameObject effect_Star2;
    [SerializeField]
    GameObject effect_Star3;
    [SerializeField]
    GameObject effect_White;



    [SerializeField]
    GameObject effect_Exit;

    private void Start()
    {
        miniGameController = GameObject.FindGameObjectWithTag("GameController");
    }

    void PlayEffect_Ready()
    {
        Instantiate(effect_Ready, miniGameController.transform);
    }

    void PlayEffect_Start()
    {
        Instantiate(effect_Start, miniGameController.transform);
    }

    void PlayEffect_Great()
    {
        Instantiate(effect_Great, miniGameController.transform);
        Instantiate(effect_White, miniGameController.transform);
    }

    void PlayEffect_Star()
    {
        star_Achived = miniGameController.GetComponent<EventController>().stars_Achived;

        if (star_Achived > 0)
        {
            Instantiate(effect_Star1, miniGameController.transform);
        }
    }

    void PlayEffect_Star_2()
    {
        star_Achived = miniGameController.GetComponent<EventController>().stars_Achived;

        if (star_Achived > 1)
        {
            Instantiate(effect_Star2, miniGameController.transform);
        }

    }

    void PlayEffect_Star_3()
    {
        star_Achived = miniGameController.GetComponent<EventController>().stars_Achived;

        if (star_Achived > 2 )
        {
            Instantiate(effect_Star3, miniGameController.transform);
        }
    }




    void StartGame()
    { 
        miniGameController.GetComponent<EventController>().miniGame_Start = true;
    }




}
