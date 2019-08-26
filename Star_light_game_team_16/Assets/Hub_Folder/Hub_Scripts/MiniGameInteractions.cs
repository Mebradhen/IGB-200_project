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
    GameObject HubControllerGameObject;

    [SerializeField]
    string sceneName; 

    // Start is called before the first frame update
    void Start()
    {
        HubControllerGameObject = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SceneManager.LoadScene(sceneName);
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
        HubControllerGameObject.GetComponent<HubController>().TriggerFade();
        timerActive = true;
    }
}
