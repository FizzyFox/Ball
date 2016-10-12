
using System;
using UnityEngine;
using System.Collections;

public class LoadWalls : MonoBehaviour {
	private GameObject hazard;
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

		using(WWW www = WWW.LoadFromCacheOrDownload(BundleURL,0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Instantiate (bundle.LoadAsset (AssetName));
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
		    bundle.Unload(false);
		}
	}

}