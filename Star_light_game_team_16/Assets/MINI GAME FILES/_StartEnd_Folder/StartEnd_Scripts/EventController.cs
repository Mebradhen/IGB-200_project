using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// author: Alex Fraser
/// 
/// this the the core controler the you guys will be interacting with
/// to set up your minigame. 
/// 
/// you will need to:
/// 1 - set change the defult timerto something suited for your game
///    and its  difficulty.
/// 2 - link to this script in your minigames code to tell it
///     2.1 - when the game starts (link your script to miniGame_Start bool variable , 
///                                 aka this script will tell you when your game should be activated)
///     3.3 - when the game ends (you tell this script that the game has ended)
///     
/// any quetions just ask :D
/// </summary>

public class EventController : MonoBehaviour
{
    //Both slides are added to this in inspector;
    [SerializeField]
    Animator[] animators;

    //minigame should be activated when this value is true
    public
    bool miniGame_Start = false;

    //if the minigame has finished turn this value to true in your own
    //scripts
    public
    bool miniGame_Ended = false;

    //how many starts the player has achived, this infomation will be sent
    //to the animation controler to display the correct star value at the 
    //end of the round.
    public
    int stars_Achived;

    //howlong before the scene swaps defult 2
    [SerializeField]
    float SwapScenes = 2;

    [SerializeField]
    string SceneToLoad = "Main_Menu";

    //star timer, this will cound down from its defult value to 0
    //at 25,50 and 75% the star acuhived from the level will be calulated.
    public
    float star_Timer_Value = 10;
    //this is used to calculate the player star score
    //float star_Timer_Value_Reference;
    float oneStarTime;
    float twoStarTime;
    float threeStarTime;

    [Header("CrossButton, JoyPad, ShoulderButton, DPad")]
    [Header("SquareButton, CircleButton, TriangleButton,")]
    [Header("Name DataName something from this list:")]

    //this is the name of the data in the savedata script
    [SerializeField]
    string DataName = "Null";


    //this is the timer
    [SerializeField]
    Slider timerBar;

    //these are the stars that are attached to the timer
    [SerializeField]
    GameObject sliderStar1;
    [SerializeField]
    GameObject sliderStar2;
    [SerializeField]
    GameObject sliderStar3;

    //controlles the fade and scene swapping
    GameObject SceneSwapper;

    bool endGameSingleCall = false;


    private void Start()
    {
        //set the referecnce on start
        float star_Timer_Value_Reference = star_Timer_Value;

        //set the max bar value the original time
        timerBar.maxValue = star_Timer_Value_Reference;

        //set refeceses
        oneStarTime = (star_Timer_Value_Reference / 4) * 1;
        twoStarTime = (star_Timer_Value_Reference / 4) * 2;
        threeStarTime = (star_Timer_Value_Reference / 4) * 3;

        //getSceneSwapper
        SceneSwapper = GameObject.FindGameObjectWithTag("SceneController");

    }

    // Update is called once per frame
    void Update()
    {
        //first check is the game has ended
        if (miniGame_Ended)
        {
            if (endGameSingleCall == false)
            {
                singleCallGameEnd();
            }
            GameEnd();
        }



        //update the timer;
        if (miniGame_Start)
            if (miniGame_Ended != true)
                if (star_Timer_Value >= 0)
                    star_Timer_Value -= Time.deltaTime;

        timerBar.value = star_Timer_Value;

        //calculate player star score
        stars_Achived = UpdateStarScore();
        if (stars_Achived == 2)
            sliderStar3.GetComponent<Animator>().SetBool("Lost",true);

        if (stars_Achived == 1)
            sliderStar2.GetComponent<Animator>().SetBool("Lost", true);

        if (stars_Achived == 0)
            sliderStar1.GetComponent<Animator>().SetBool("Lost", true);



    }

    int UpdateStarScore()
    {
        //returns the star value
        if (star_Timer_Value < oneStarTime)
            return 0;

        if (star_Timer_Value < twoStarTime)
            return 1;

        if (star_Timer_Value < threeStarTime)
            return 2;

        return 3;
    }

    public void singleCallGameEnd()
    {
        endGameSingleCall = true;

        //find the dataholder then add the scopre to the data
        GameObject dataHolder = GameObject.FindGameObjectWithTag("DataManager");
        SaveData saveData = dataHolder.GetComponent<SaveData>();
        //saveData.pathData

        foreach (SaveData.MiniGamePathData minigame in saveData.pathData)
        {
            if (DataName == "Null")
            {
                print("change the Null value in the event controller script");
            }

            if (minigame.miniGamePath == DataName)
            {
                minigame.progression += stars_Achived;
                break;
            }
        }

        saveData.PrintData();
    }

    public void GameEnd()
    {
        foreach (var animator in animators)
            animator.GetComponent<Animator>().SetBool("MiniGameEnded", true);

        SwapScenes -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1")|| SwapScenes <= 0)
        {
            SceneSwapper.GetComponent<SwapScenes>().returnToScene = true;
            
            //SceneManager.LoadScene(SceneToLoad);
        }
    }
}
