using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniGameInteractions : MonoBehaviour
{
    
    bool timerActive;
    [SerializeField]
    float timer = 2;

    [SerializeField]
    GameObject hubControllerGameObject;
    GameObject sceneGameObject;

    [SerializeField]
    string sceneName; 

    // Start is called before the first frame update
    void Start()
    {
        hubControllerGameObject = GameObject.FindGameObjectWithTag("GameController");
        sceneGameObject = GameObject.FindGameObjectWithTag("SceneController");
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnMouseOver()
    {
        this.GetComponent<Animator>().SetBool("Hovered", true);
    }

    private void OnMouseExit()
    {
        this.GetComponent<Animator>().SetBool("Hovered", false);
    }

    private void OnMouseDown()
    {
        hubControllerGameObject.GetComponent<HubController>().TriggerFade();
        timerActive = true;
    }
}
