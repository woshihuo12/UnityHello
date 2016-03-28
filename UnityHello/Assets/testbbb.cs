using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class testbbb : MonoBehaviour
{

    // Use this for initialization

    private void Awake()
    {
        Debug.Log("Awake");
    }

    void Start()
    {
        Debug.Log("Start");
        transform.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("hhhhhhhhhhhhhhhhhh"); });
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
    }
}
