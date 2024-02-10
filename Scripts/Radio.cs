using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public string radioURL = "https://europaplus.hostingradio.ru:8014/europaplus320.mp3";
    private AudioSource audioSource;

    IEnumerator Start()
    {
        using (var www = new WWW(radioURL))
        {
            yield return www;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = www.GetAudioClip(false, false, AudioType.MPEG);
            audioSource.Play();
        }
    }
}
