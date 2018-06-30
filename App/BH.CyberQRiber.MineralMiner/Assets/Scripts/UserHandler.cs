using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserHandler : MonoBehaviour {

    private readonly string APIAddress = "http://localhost:56492";
    private readonly string Username = "username"; //TODO: placeholders make configuration
    private readonly string BlockchainAddress = "address";
    private int LoggedInId;
	// Use this for initialization
	void Start () {
        LoggedInId = (int)LogInUser().Current;

    }
	
    IEnumerator LogInUser()
    {
        var request = UnityWebRequest.Post(APIAddress + "/api/OnlineUsers", $"{{'UserName' : '{Username}', 'BlockChainAddress: '{BlockchainAddress}'}}");
        var response = request.SendWebRequest();
        yield return response;

        if (request.error == null)
        {
            // request completed!
        }
        else
        {
            // something wrong!
            Debug.Log("WWW Error: " + request.error);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        LogOutUser();
    }

    IEnumerator LogOutUser()
    {
        var request = UnityWebRequest.Delete(APIAddress + $"api/OnlineUsers/{LoggedInId}");
        var response = request.SendWebRequest();
        yield return response;

        if (request.error == null)
        {
            // request completed!
        }
        else
        {
            // something wrong!
            Debug.Log("WWW Error: " + request.error);
        }
    }
}
