using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class BundleWebLoader : MonoBehaviour {
    void Start() {
        StartCoroutine(GetAssetBundle());
    }
 
    IEnumerator GetAssetBundle() {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("https://drive.google.com/uc?export=download&id=1LS4tihA-zRqqs7aPFJeTfPtmMY6i7P7u");
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        }
    }
}