using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour
{
    void Start()
    {
        AppFacade.Instance.StartUp();   //启动游戏
    }
}
