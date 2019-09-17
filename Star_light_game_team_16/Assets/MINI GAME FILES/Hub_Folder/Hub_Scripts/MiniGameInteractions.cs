using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameInteractions : MonoBehaviour
{
    
    bool timerActive;
    [SerializeField]
    float timer = 2;

    bool hovered = false;

    [SerializeField]
    bool locked = true;

    GameObject hubControllerGameObject;
    GameObject sceneGameObject;

    [SerializeField]
    string sceneName;

    [SerializeField]
    int difficultyRating = 0;

    [SerializeField]
    string saveDataName;

    GameObject saveDataGaneObject;



    // Start is called before the first frame update
    void Start()
    {
        hubControllerGameObject = GameObject.FindGameObjectWithTag("GameController");
        sceneGameObject = GameObject.FindGameObjectWithTag("SceneController");
        saveDataGaneObject = GameObject.FindGameObjectWithTag("DataManager");
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (difficultyRating <= saveDataGaneObject.GetComponent<SaveData>().FindDataFromName(saveDataName))
            {
                locked = false;
            }
        }
        catch (System.Exception)
        {
            
        }


        changeBasedOnHoveredState();

        if (timerActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                sceneGameObject.GetComponent<SwapScenes>().sceneName = sceneName;
                sceneGameObject.GetComponent<SwapScenes>().returnToScene = true;
            }
        }


    }

    private void OnMouseDown()
    {
        if (locked)
        {

        }
        else
        {
            hubControllerGameObject.GetComponent<HubController>().TriggerFade();
            timerActive = true;
        }

    }

    private void OnMouseOver()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        hovered = false;
    }

    void changeBasedOnHoveredState()
    {
        if (hovered)
        {
            if (locked)
            {
                this.GetComponent<Renderer>().material.color = Color.white;
                activateChild(false);
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.red;
                hovered = true;
                activateChild(true);
                MiniGameIconAnim(true);

            }
        }
        else
        {
            if (locked)
            {
                this.GetComponent<Renderer>().material.color = Color.gray;
                activateChild(false);
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.blue;
                hovered = false;
                activateChild(true);
                MiniGameIconAnim(false);
            }
        }
    }

    void activateChild(bool active)
    {
        GameObject child = this.transform.GetChild(0).transform.gameObject;
        child.SetActive(active);
    }

    void MiniGameIconAnim(bool hoverd)
    {
        GameObject child = this.transform.GetChild(0).transform.gameObject;
        child.GetComponent<Animator>().SetBool("Hovered", hoverd);
    }
}
