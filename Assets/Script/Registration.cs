using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;
public class Registration : MonoBehaviour
{
    public TMP_InputField username, password;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());

    }

    IEnumerator  Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);

        using (var www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("User created succesfully!");
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("User creation failed! Error #" + www.result);
            }
        }   
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (username.text.Length >= 8 && password.text.Length >= 8);
    }
}
