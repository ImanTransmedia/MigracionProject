using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundle : MonoBehaviour
{
    [SerializeField] private string url = "";

    // Start is called before the first frame update
    void Start()
    {
        WWW www = new WWW(url);
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerator webReq (WWW www){

            yield return www;


            while (www.isDone == false) {
            yield return null;
            }

            AssetBundle bundle = www.assetBundle;

            if (www.error == null) {

                GameObject obj = (GameObject)bundle.LoadAsset("");
            }
            else
            {
                Debug.Log(www.error);
            }

        }        
    }
}
