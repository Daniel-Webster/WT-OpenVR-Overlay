
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void OnSuccess(string json);
public delegate void OnTextureSuccess(Texture2D tex, byte[] data);
public class HTTPRequest
{

    public static IEnumerator GetRecursive(string uri, OnSuccess callback)
    {
        return GetRecursive(uri, callback, 0);
    }
    public static IEnumerator GetRecursive(string uri, OnSuccess callback, int waitTimeSeconds)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            //Debug.Log("hello");
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
            
            if (webRequest.isNetworkError)
            {
                Debug.LogError(uri + ": Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(uri + ":\nReceived: " + webRequest.downloadHandler.text);
                callback(webRequest.downloadHandler.text);
            }
            //Debug.Log("getagain");
            if(waitTimeSeconds > 0) {
                yield return new WaitForSeconds(waitTimeSeconds);
            }
            yield return GetRecursive(uri, callback, waitTimeSeconds);
            //Debug.Log("get finished!");
        }
    }   

    public static IEnumerator GetTextureImage(string uri, OnTextureSuccess callback) {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return webRequest.SendWebRequest();
            
            if (webRequest.error != null || webRequest.isNetworkError)
            {
                Debug.LogError(uri + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Got image successfully");
                Texture2D myTexture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
                Debug.Log(myTexture);
                Debug.Log(webRequest.downloadHandler.data[3550]);
                callback(myTexture, webRequest.downloadHandler.data);
            }
        }
    }  
}
