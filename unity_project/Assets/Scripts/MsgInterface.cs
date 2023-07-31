using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MsgInterface : MonoBehaviour
{

    public Text txtSendMsg;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSendMessageToBrowser()
    {
        string send_msg = txtSendMsg.text;
        Debug.Log("Sending Message : " + send_msg);
    }

    
}
