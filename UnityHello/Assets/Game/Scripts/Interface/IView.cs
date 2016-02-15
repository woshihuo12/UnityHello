using UnityEngine;
using System.Collections;

public interface IView
{
    void OnMessage(IMessage message);
}
