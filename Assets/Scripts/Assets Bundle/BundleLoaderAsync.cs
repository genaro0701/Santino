using System.Collections;
using System.IO;
using UnityEngine;

public class BundleLoaderAsync : MonoBehaviour
{
    [SerializeField] string assetName = "Player";
    [SerializeField] string bundleName = "Prefabs";
    private string assetBundleDirectory = Application.dataPath + "/../AssetBundles";

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(AssetBundleLoadAsync());
    }

    public void LoadAssetBundles()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(assetBundleDirectory, bundleName));

        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            return;
        }

        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);

        localAssetBundle.Unload(false);
    }

    private IEnumerator AssetBundleLoadAsync()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(Path.Combine(assetBundleDirectory, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle!");
            yield break;
        }

        AssetBundleRequest assetRequest = localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = assetRequest.asset as GameObject;
        Instantiate(prefab);

        localAssetBundle.Unload(false);
    }
}
