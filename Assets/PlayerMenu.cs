using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenu : MonoBehaviour {
	public GameObject player;
	//public GameObject game;
	public Text counttext;
	public Text wintext;
	public Text wintext2;
	public Text records;
	public GameObject can;
	public GameObject rest;
	public GameObject win;
	private static int count;
	private int record;

	void Start () {
		count = 0;
		SetCountText ();
		can.SetActive(false);
		rest.SetActive(false);

		wintext.text = "";
		wintext2.text = "" ;
		win.SetActive (false);
		record = PlayerPrefs.GetInt ("Main");
		records.text = "Record:"+record.ToString() ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision other)
	{
		if (player==null) {
			//player.gameObject.SetActive (false);
			//game.SetActive (false);
			rest.SetActive(true);
			GetCountText ();
		}

		if (other.gameObject.tag == "Coin") {
			count = count + 10;
			Destroy (other.gameObject);
			SetCountText ();

		}
	}
	void SetCountText ()
	{
		counttext.text = "Count: " + count.ToString();


	}
	void GetCountText ()
	{
		win.SetActive (true);

		if (count > record) {
			PlayerPrefs.SetInt ("Main", count);
			PlayerPrefs.Save ();
			record = count;
			record = PlayerPrefs.GetInt ("Main");
			wintext2.text = "You lose!" ;
			wintext.text = "New record:" + record.ToString ();
			records.text = "Record:" + record.ToString ();
		} else {
			wintext.text = "You lose!" + count.ToString ();
		}

	}

	public void ButtonMenu(){
		can.SetActive (true);


	}
	public void ButtonClose(){

		can.SetActive (false);

	}
}
