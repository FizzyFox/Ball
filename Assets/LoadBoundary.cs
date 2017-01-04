
using System;
using UnityEngine;
using System.Collections;

public class LoadBoundary : MonoBehaviour {
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
			Instantiate (bundle.LoadAsset (AssetName));
			bundle.Unload(false);
		}
	}

}