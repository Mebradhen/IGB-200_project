using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SaveData : MonoBehaviour
{

    public List<MiniGamePathData> pathData = new List<MiniGamePathData>();


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public class MiniGamePathData
    {
        public int progression;
        public string miniGamePath;

        public MiniGamePathData(string MGPath, int Prgs)
        {
            miniGamePath = MGPath;
            progression = Prgs;
        }

        public MiniGamePathData(string MGPath)
        {
            miniGamePath = MGPath;
            progression = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        pathData.Add( new MiniGamePathData("SquareButton"));
        pathData.Add(new MiniGamePathData("CircleButton"));
        pathData.Add(new MiniGamePathData("TriangleButton"));
        pathData.Add(new MiniGamePathData("CrossButton"));
        pathData.Add(new MiniGamePathData("JoyPad"));
        pathData.Add(new MiniGamePathData("ShoulderButton"));
        pathData.Add(new MiniGamePathData("DPad"));


        PrintData();
    }

    // Update is called once per frame
    public void PrintData()
    {
        foreach (MiniGamePathData minigame in pathData)
        {
            print("miniGamePath: " + minigame.miniGamePath + "\n minigame progression: " + minigame.progression);
        }
    }
}
