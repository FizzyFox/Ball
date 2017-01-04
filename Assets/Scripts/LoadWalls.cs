
using System;
using UnityEngine;
using System.Collections;

public class LoadWalls : MonoBehaviour {
	private GameObject hazard;
	public string BundleURL;
	public string BundleURL_ground;
	public string BundleURL_wall;
	public string AssetName;
	public string Ground;
	public string Wall;

	void Start() {
		//Rigidbody rb = GetComponent<Rigidbody> ();	
		StartCoroutine (Download());
		StartCoroutine (Texture_ground());
		StartCoroutine (Texture_wall());

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

	IEnumerator Texture_ground(){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload(BundleURL_ground,0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Material  texture = bundle.LoadAsset(Ground) as Material;
			//Material  texture1 = bundle.LoadAsset(textureName1) as Material;

			//Instantiate (bundle.LoadAsset (AssetName));
			if(texture != null){
				Debug.Log ("Загружены материалы");
			}
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			bundle.Unload(false);
		}
	}
	IEnumerator Texture_wall(){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload(BundleURL_wall,0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Material  texture = bundle.LoadAsset(Wall) as Material;
			//Material  texture1 = bundle.LoadAsset(textureName1) as Material;

			//Instantiate (bundle.LoadAsset (AssetName));
			if (texture == null) {
				Debug.Log ("Загружены материалы1");
			} else {
				Debug.Log ("Загружены не материалы1");
			}
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			bundle.Unload(false);
		}
	}
}