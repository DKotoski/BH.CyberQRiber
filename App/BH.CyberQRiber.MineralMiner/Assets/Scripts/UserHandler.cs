using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UserHandler : MonoBehaviour
{

    private readonly string APIAddress = "http://localhost:56492";
    private readonly string _userName = "username"; //TODO: placeholders make configuration
    private readonly string _blockchainAddress = "address";
    private int LoggedInId;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LogInUser());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        LogOutUser().MoveNext();
    }

    IEnumerator LogInUser()
    {

        var route = APIAddress + "/api/onlineusers";
        var form = new Dictionary<string, string>();
        form.Add("userName", _userName);
        form.Add("blockChainAddress", _blockchainAddress);
        UnityWebRequest www = UnityWebRequest.Post(route, form);
        www.method = "POST";
        www.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            LoggedInId = 0;
            // something wrong!
            Debug.Log("WWW Error: " + www.error);
        }
        else
        {
            // request completed!
            var result = JsonConvert.DeserializeObject<LoginUserModelResponse>(www.downloadHandler.text);
            LoggedInId = result?.id ?? 0;
        }
    }

    IEnumerator LogOutUser()
    {
        var route = APIAddress + $"/api/onlineusers/{LoggedInId}";
        UnityWebRequest www = UnityWebRequest.Delete(route);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            LoggedInId = 0;
            // something wrong!
            Debug.Log("WWW Error: " + www.error);
        }
        else
        {
            // request completed!
            LoggedInId = 0;
        }
    }
}


[System.Serializable]
public class LoginUserModelRequest
{
    public string UserName { get; set; }
    public string BlockChainAddress { get; set; }
}

[System.Serializable]
public class LoginUserModelResponse
{
    public int id { get; set; }
    public string userName { get; set; }
    public string blockChainAddress { get; set; }
}