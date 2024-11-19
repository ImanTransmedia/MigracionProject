// 2024-11-18 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AssetBundleDownloaderV2 : MonoBehaviour
{
    public string bundleURL = "https://example.com/path/to/your/assetbundle.bundle"; // Cambia a tu URL
    public string assetName = "nombre-del-asset"; // Nombre del asset dentro del bundle que deseas cargar

    void Start()
    {
        StartCoroutine(DownloadAndCache());
    }

    IEnumerator DownloadAndCache()
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(bundleURL))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error descargando asset bundle: " + uwr.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);

                if (bundle != null)
                {
                    // Cargar el asset específico del bundle
                    var asset = bundle.LoadAsset<GameObject>(assetName);
                    if (asset != null)
                    {
                        Instantiate(asset);
                    }
                    else
                    {
                        Debug.LogError("No se pudo cargar el asset del bundle");
                    }

                    // No olvides descargar el asset bundle después de usarlo
                    bundle.Unload(false);
                }
            }
        }
    }
}
