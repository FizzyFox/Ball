using UnityEngine;
using System.Collections;

public class MenuPlayer : MonoBehaviour {
	bool isOutsideScreen=false;
	//public GameObject ball;
	public GUISkin skin;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI() 
	{
		GUI.skin = skin;
		//if (isOutsideScreen == true) {
			GUI.Box (new Rect (Screen.width / 2 - 260, Screen.height / 2 + 230, 520, 70),"");
			if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 235, 160, 60), "Рестарт")) {
				Application.LoadLevel ("Main");
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 80, Screen.height / 2 + 235, 160, 60), "Главное меню")) {
				Application.LoadLevel ("Menu");
			}
		if (GUI.Button (new Rect (Screen.width / 2 + 90, Screen.height / 2+235 , 160, 60), "Выход")) {
			Application.Quit();
		}
		//}
	}

}
