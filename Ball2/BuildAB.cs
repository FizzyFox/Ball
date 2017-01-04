using UnityEngine;
using UnityEditor;


public class BuildAB
{
	[MenuItem ("Assets/Build AssetBundles for Android")]
	static void BuildAllAssetBundles ()
	{
		//BuildPipeline.BuildAssetBundles ("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXUniversal);
		
		BuildPipeline.BuildAssetBundles ("Assets/AssetBundles/Android",BuildAssetBundleOptions.None,BuildTarget.Android);
		//BuildPipeline.BuildAssetBundle("Assets/AssetBundles",BuildAssetBundleOptions.None,BuildTarget.Android);

	}
}
