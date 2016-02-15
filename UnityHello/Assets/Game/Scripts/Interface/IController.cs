using System;
using System.Collections;

public interface IController
{
    void RegisterCommand(string messageName, Type commandType);
    void RegisterViewCommand(IView view, string[] commandNames);
    void ExecuteCommand(IMessage message);
    void RemoveCommand(string messageName);
    void RemoveViewCommand(IView view, string[] commandNames);
    bool HasCommand(string messageName);
}
