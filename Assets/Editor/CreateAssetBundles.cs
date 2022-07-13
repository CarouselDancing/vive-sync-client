using UnityEditor;
using System.IO;

public class CreateAssetBundles
{
    [MenuItem("Build Asset Bundles/Normal")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
                                        BuildAssetBundleOptions.None, 
                                        BuildTarget.StandaloneWindows);
    }

   //Creates a new item (Chunk Based Compression) in the new Build Asset Bundles menu
    [MenuItem("Build Asset Bundles/Chunk Based Compression ")]
    static void BuildABsChunk()
    { 
        string assetBundleDirectory = "Assets/AssetBundles";
          if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        //Build the AssetBundles in this mode
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
                                        BuildAssetBundleOptions.ChunkBasedCompression,
                                        BuildTarget.StandaloneWindows);
    }

}
