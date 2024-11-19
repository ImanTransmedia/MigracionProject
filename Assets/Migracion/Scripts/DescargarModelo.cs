using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class DescargarModelo : MonoBehaviour
{
    //string Nombre;
    public float progresoDescarga;
    public GameObject modelo = null;
    public string url;
    public AssetBundle bundle1;
    [SerializeField] private GameObject[] ImageTarget; 
    public GameObject Instancia; 


    public void Start()
    {
        //Descargar();
        
    }

    public void Descargar()
    {
        StartCoroutine(downloadObject());
    }

    public void Limpiar()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        DestroyImmediate(modelo, true);
        DestroyImmediate(Instancia, true);
    }


    public IEnumerator downloadObject()
    {
        UnityWebRequest www1 = UnityWebRequestAssetBundle.GetAssetBundle(url);
        var operation = www1.SendWebRequest();

        while (!operation.isDone)
        {
            progresoDescarga = www1.downloadProgress * 100;

            yield return null;
        }


        if (operation.isDone)
        {
            bundle1 = DownloadHandlerAssetBundle.GetContent(www1);
            //obtener nombre del asset 
            string rootAssetPath = bundle1.GetAllAssetNames()[0];
            GameObject arObject = bundle1.LoadAsset(rootAssetPath) as GameObject;
            modelo = arObject;

            foreach (var target in ImageTarget) {

                Instancia = Instantiate(modelo, target.transform);
                
            }
            


        }

    }



}
