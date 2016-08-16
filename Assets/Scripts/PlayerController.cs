using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

//	void Start()
//	{
//
//	}
	void Update ()
	{
		if (( Input.GetButton ("Fire1") || Input.GetKey (KeyCode.Space) ) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); // as GameObject;
			GetComponent<AudioSource>().Play();
		}
	}
//	void CalibrateAccellerometer()
//	{
//		Vector3 accelerationSnapshot = Input.acceleration;
//		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
//		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
//	}
//	void FixAcceleration(Vector3 acceleration)
//	{
//		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
//		return fixedAcceleration;
//	}

	void FixedUpdate ()
	{
		
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");

//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 acceleration = Input.acceleration;

		Vector3 movement = new Vector3 (acceleration.x, 0.0f, acceleration.y);
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}



}
