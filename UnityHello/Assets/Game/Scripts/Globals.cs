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
}
