using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScenes : MonoBehaviour
{
    public bool returnToScene;

    
    public string sceneName = "Hub";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (returnToScene)
        {
            this.GetComponent<Animator>().SetBool("Return", true);
        }
    }

    public void SwitchToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
