using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_count : MonoBehaviour
{

    public int count = 0;
    private GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        EventController EC = gameController.GetComponent<EventController>();

        if (count >= 11) {
            EC.miniGame_Ended = true;
        }
       
    }
}
