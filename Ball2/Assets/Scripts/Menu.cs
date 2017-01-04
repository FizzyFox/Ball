using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	//public Text menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ButtonMenu(){
		Application.LoadLevel ("Menu");
	}

	public void ButtonExit(){
		
		Application.Quit ();
	}
	public void ButtonRestart(){
		Application.LoadLevel ("Main");
	}


}
