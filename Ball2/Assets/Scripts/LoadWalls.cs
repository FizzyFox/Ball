
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
		
			Instantiate (bundle.LoadAsset (AssetName));
			if((bundle != null)){
				Debug.Log ("загружена платформа");
			}

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

			if(texture != null){
				Debug.Log ("Загружены материалы для основания");
			}

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
			if (texture != null) {
				Debug.Log ("Загружены материалы для стен");
			} else {
				Debug.Log ("Не загружены  материалы для стен");
			}

			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			bundle.Unload(false);
		}
	}
}