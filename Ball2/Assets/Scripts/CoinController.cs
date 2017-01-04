using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {
	private GameObject hazard;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public string BundleURL;
	public string BundleURL_mat;
	public string AssetName;
	public string Coins;


	void Start() {
		
		Rigidbody rb = GetComponent<Rigidbody> ();	 
			StartCoroutine(SpawnWaves ());
		StartCoroutine (DownloadAndCache());
		StartCoroutine (Coin());
	}

	IEnumerator DownloadAndCache (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;

				Instantiate(bundle.LoadAsset(AssetName));

			if((bundle != null)){
				Debug.Log ("загружена монета");
			}
			hazard = bundle.LoadAsset (AssetName) as GameObject;
			yield return hazard;
			// Unload the AssetBundles compressed contents to conserve memory
			bundle.Unload(false);
		}
	}
	IEnumerator Coin (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL_mat, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;
			Material  texture = bundle.LoadAsset(Coins) as Material;

			if ((bundle != null)) {
				Debug.Log ("загружена материал монеты");
			} else {
				Debug.Log ("не загружена материал монеты");
			}

			bundle.Unload(false);
		}
	}

	
	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}

	}


}
