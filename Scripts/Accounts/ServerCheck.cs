using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ServerCheck : MonoBehaviour
{
    public string serverAddress = "https://anchosus.itch.io/projectsky";
    public Text connectionText;

    IEnumerator Start()
    {
        while (true)
        {
            using (var webRequest = UnityEngine.Networking.UnityWebRequest.Get(serverAddress))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    connectionText.text = "Connected to " + serverAddress;
                }
                else
                {
                    connectionText.text = "Connection to " + serverAddress;
                }
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
