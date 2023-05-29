using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateAssetBundle : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = Application.dataPath + "/../AssetBundles";

        try
        {
            if (!Directory.Exists(Application.streamingAssetsPath))
            {
                Directory.CreateDirectory(assetBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
        
    }
}
