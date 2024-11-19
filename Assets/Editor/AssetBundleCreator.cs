using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/BundledAssets";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        // Usar compresión LZ4
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
            BuildAssetBundleOptions.ChunkBasedCompression, 
            EditorUserBuildSettings.activeBuildTarget);

        Debug.Log("Asset Bundles construidos con compresión LZ4 en: " + assetBundleDirectory);
    }
}