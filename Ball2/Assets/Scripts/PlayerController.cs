using UnityEngine;
using UnityEngine.UI;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
public class PlayerController : MonoBehaviour {
	
	public Boundary boundary;
    public GameObject game;
	private Rigidbody rb;
	public Text counttext;
	public Text wintext;
	public Text wintext2;
	public Text records;
	public GameObject can;
	public GameObject rest;
	public GameObject win;

	public AudioSource audio;
	bool isOutsideScreen=false;
	private static int count;
	private int record;
	private Quaternion calibrationQuaternion;
	void Start(){
		CalibrateAccelerometer ();
		rb = GetComponent<Rigidbody> ();

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




	void CalibrateAccelerometer(){
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}
	Vector3 FixAcceleration (Vector3 acceleration){
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}
		
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		/*Vector3 accelerate = Input.acceleration;
		Vector3 acceleration = FixAcceleration (accelerate);
		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);*/

		rb.velocity= movement*10;
		rb.position = new Vector3
(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
				(-5.5f), Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -5);

	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Enemy") {
		this.gameObject.SetActive (false);
			game.SetActive (false);
			rest.SetActive(true);
			GetCountText ();
		}

		if (other.gameObject.tag == "Coin") {
			count = count + 10;
			Destroy (other.gameObject);
			SetCountText ();
			audio.Play ();
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
