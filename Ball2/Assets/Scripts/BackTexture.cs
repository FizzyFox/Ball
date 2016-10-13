using UnityEngine;
using System.Collections;

public class BackTexture : MonoBehaviour {
	public string BundleURL;
	public string AssetName;


	void Start() {

		StartCoroutine (Download());
	}

	IEnumerator Download (){
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, 0)){
			yield return www;
			AssetBundle bundle = www.assetBundle;
			GameObject hazard = bundle.LoadAsset (AssetName) as GameObject;
			Instantiate (hazard);
			bundle.Unload(false);
		}
	}

}
	