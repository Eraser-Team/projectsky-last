using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class LoginSystem : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;

    private string jsonUrl = "http://gamepanelaccounts.7m.pl/accounts.json";

    private void Start()
    {
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    private void OnLoginButtonClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        StartCoroutine(Login(username, password));
    }

    private IEnumerator Login(string username, string password)
    {
        UnityWebRequest request = UnityWebRequest.Get(jsonUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            AccountData[] accounts = JsonHelper.FromJson<AccountData>(json);

            foreach (AccountData account in accounts)
            {
                if (account.username == username)
                {
                    if (account.password == password)
                    {
                        Debug.Log("Login successful!");
                        Debug.Log("Username: " + account.username);
                        Debug.Log("Password: " + account.password);
                        // Добавьте здесь код для перехода на следующую сцену или выполнения других действий после успешного входа.
                        yield break;
                    }
                    else
                    {
                        Debug.Log("Login failed. Incorrect password.");
                        yield break;
                    }
                }
            }

            Debug.Log("Login failed. Username not found.");
        }
        else
        {
            Debug.Log("Failed to load JSON: " + request.error);
        }
    }

    [System.Serializable]
    private class AccountData
    {
        public string username;
        public string password;
    }

    private static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.items;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
    }
}