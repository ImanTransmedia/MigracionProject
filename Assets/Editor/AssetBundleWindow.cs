// 2024-11-14 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AssetBundleWindow : EditorWindow
{
    [MenuItem("Window/Asset Bundle Creator")]
    public static void ShowWindow()
    {
        var window = GetWindow<AssetBundleWindow>();
        window.titleContent = new GUIContent("Asset Bundle Creator");
    }

    private void OnEnable()
    {
        // Cargar el archivo UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/AssetBundleWindow.uxml");
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Styles.uss");

        var root = rootVisualElement;
        visualTree.CloneTree(root);

        // Aplicar el estilo USS
        root.styleSheets.Add(styleSheet);

        // Configurar eventos de arrastre y suelta
        var dropArea = root.Q<VisualElement>("dropArea");
        dropArea.RegisterCallback<DragUpdatedEvent>(evt =>
        {
            if (DragAndDrop.objectReferences.Length > 0 && DragAndDrop.objectReferences[0] is GameObject)
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
            }
        });

        dropArea.RegisterCallback<DragPerformEvent>(evt =>
        {
            var prefab = DragAndDrop.objectReferences[0] as GameObject;
            if (prefab != null)
            {
                BuildAssetBundleFromPrefab(prefab);
            }
        });
    }

    private void BuildAssetBundleFromPrefab(GameObject prefab)
    {
        string assetBundleDirectory = "Assets/Migracion/Assets bundles";
        if (!System.IO.Directory.Exists(assetBundleDirectory))
        {
            System.IO.Directory.CreateDirectory(assetBundleDirectory);
        }

        // Crear un AssetBundle solo con el prefab seleccionado
        AssetBundleBuild build = new AssetBundleBuild();
        build.assetBundleName = prefab.name + ".bundle";
        build.assetNames = new string[] { AssetDatabase.GetAssetPath(prefab) };

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, new AssetBundleBuild[] { build }, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        Debug.Log("Asset Bundle creado para prefab: " + prefab.name);
    }
}
