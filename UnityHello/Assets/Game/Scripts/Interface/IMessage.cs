using UnityEngine;
using System.Collections;

public interface IMessage
{
    string Name { get; }
    object Body { get; set; }
    string Type { get; set; }
    string ToString();
}
