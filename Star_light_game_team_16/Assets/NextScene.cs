using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        int index = currentscene.buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
