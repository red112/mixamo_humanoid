using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class msgAPI : MonoBehaviour
{
    private msgAPI instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // API
    public void  SendMsg(string msg)
    {
        Debug.Log("SendMsg : "+msg);
    }

    public void ReceiveMsg(string msg)
    {
        Debug.Log("ReceiveMsg : " + msg);
    }
}
