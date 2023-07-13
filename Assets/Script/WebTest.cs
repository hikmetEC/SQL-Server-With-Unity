using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        var www = UnityWebRequest.Get("http://localhost/sqlconnect/webtest.php");
        yield return www.SendWebRequest();
        string[] webResults = www.downloadHandler.text.Split("\t");
        foreach(string res in webResults)
        {
            Debug.Log(res);
        }
    }

   
}
