using UnityEngine;
using System.Collections;

public interface ICommand
{
    void Execute(IMessage message);
}
