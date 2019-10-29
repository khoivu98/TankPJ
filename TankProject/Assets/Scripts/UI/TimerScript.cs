using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TimerScript : NetworkBehaviour {

    [SyncVar]
    public float time = 5f;

    public Text InfoText;

    void Start()
    {
        InfoText = GameObject.Find("Timer").GetComponent<Text>();
    }
    
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        InfoText.text = "Time: " + ((int)time).ToString();
        if (time <= 0)
            BackToLobby();
	}

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }
}
