#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Text;

public class KrzysztofEditorTools : MonoBehaviour
{
    [MenuItem("Assets/Krzysztof/Get Dependencies")]
    static void GetAllDependenciesForScenes()
    {
        string[] guids = AssetDatabase.FindAssets(Selection.activeObject.name);

        string[] allPaths = new string[guids.Length];
        int curIndex = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            allPaths[curIndex] = path;

        }
        string[] dependencies = AssetDatabase.GetDependencies(allPaths);

        var dependenciesString = new StringBuilder();
        dependenciesString.AppendLine();

        foreach (string curDependency in dependencies)
        {
            dependenciesString.Append(curDependency);
            dependenciesString.AppendLine();
        }

        Debug.Log("All dependencies for " + Selection.activeObject.name + ": " + dependenciesString);
    }

}

#endif