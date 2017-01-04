
using System;
using UnityEngine;
using System.Collections;

public class LoadStars : MonoBehaviour {
	//private GameObject hazard;
	public string BundleURL;
	public string BundleURL_stars;
	public string AssetName;
	public string Star_1;
	public string Star_2;
	public string material;


	void Start() {
		//Rigidbody rb = GetComponent<Rigidbody> ();	
		StartCoroutine (Download());
		StartCoroutine (Stars());
	}

	IEnumerator Download (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;

			Instantiate (bundle.LoadAsset (AssetName));
			if((bundle != null)){
				Debug.Log ("загружены звезды");
			}
			//hazard = bundle.LoadAsset (AssetName) as GameObject;
			//yield return hazard;
			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload(false);
		}
	}
	IEnumerator Stars (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL_stars, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Texture  texture = bundle.LoadAsset(Star_1) as Texture;
			Texture  texture1 = bundle.LoadAsset(Star_2) as Texture;
			Material texture2 = bundle.LoadAsset (material) as Material;

			if((texture != null)&&(texture1 != null)&&(material != null)){
				Debug.Log ("Загружены материалы для звезд");
			}

			bundle.Unload(false);
		}
	}


}