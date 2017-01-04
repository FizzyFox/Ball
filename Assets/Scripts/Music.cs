using UnityEngine;
using System.Collections;


public class Music : MonoBehaviour {
	
	static Music instance;
	// Use this for initialization

	void Start () {
		DontDestroyOnLoad (this.gameObject);
		if ((instance == null)) {
			instance = this;


		} else if ((instance != this)) {
			Destroy (this.gameObject);
		}

	}
	

}

