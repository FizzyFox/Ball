
using System;
using UnityEngine;
using System.Collections;

public class LoadStars : MonoBehaviour {
	//private GameObject hazard;
	public string BundleURL;
	public string AssetName;


	void Start() {
		//Rigidbody rb = GetComponent<Rigidbody> ();	
		StartCoroutine (Download());
	}

	IEnumerator Download (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;

			Instantiate (bundle.LoadAsset (AssetName));
			//Debug.Log("null");

			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload(false);
		}
	}

}