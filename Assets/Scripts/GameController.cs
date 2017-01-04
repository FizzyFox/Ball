using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	private GameObject hazard;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public string BundleURL;
	public string AssetName;

	void Start() {
		
		Rigidbody rb = GetComponent<Rigidbody> ();	 
			StartCoroutine(SpawnWaves ());
		StartCoroutine (DownloadAndCache());
	}

	IEnumerator DownloadAndCache (){
		// Wait for the Caching system to be ready
		while (!Caching.ready)
			yield return null;

		using(WWW www = WWW.LoadFromCacheOrDownload (BundleURL, 0)){
			yield return www;

			AssetBundle bundle = www.assetBundle;

				Instantiate(bundle.LoadAsset(AssetName));

			hazard = bundle.LoadAsset (AssetName) as GameObject;
			yield return hazard;
			// Unload the AssetBundles compressed contents to conserve memory
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
