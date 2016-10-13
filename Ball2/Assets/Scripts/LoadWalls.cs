
using System;
using UnityEngine;
using System.Collections;

public class LoadWalls : MonoBehaviour {
	private GameObject hazard;
	public string BundleURL;
	public string BundleURL1;
	public string AssetName;
	public string textureName;
	public string textureName1;

	void Start() {
		//Rigidbody rb = GetComponent<Rigidbody> ();	
		StartCoroutine (Download());
		StartCoroutine (Texture());

	}

	IEnumerator Download (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload(BundleURL,0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			//Texture  texture = bundle.LoadAsset(textureName) as Texture;
			Instantiate (bundle.LoadAsset (AssetName));
			if((bundle != null)){
				Debug.Log ("загружен");
			}
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
		    bundle.Unload(false);
		}
	}

	IEnumerator Texture(){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload(BundleURL1,0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Material  texture = bundle.LoadAsset(textureName) as Material;
			Material  texture1 = bundle.LoadAsset(textureName1) as Material;

			//Instantiate (bundle.LoadAsset (AssetName));
			if((texture1 != null)&&(texture != null)){
				Debug.Log ("Загружены материалы");
			}
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			bundle.Unload(false);
		}
	}

}