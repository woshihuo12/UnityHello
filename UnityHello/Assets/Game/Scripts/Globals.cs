using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
    public static Globals Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        AppFacade.Instance.StartUp();   //启动游戏
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    //void OnGUI()
    //{
    //    DrawFps();
    //}

    float deltaTime = 0.0f;

    private void DrawFps()
    {
        float fps = 1.0f / deltaTime;

        if (fps > 50)
        {
            GUI.color = new Color(0, 1, 0);
        }
        else if (fps > 40)
        {
            GUI.color = new Color(1, 1, 0);
        }
        else
        {
            GUI.color = new Color(1.0f, 0, 0);
        }

        GUI.Label(new Rect(50, 32, 500, 24), "fps: " + fps.ToString());

    }


}
