using UnityEngine;
using System.Collections;

public class DestroyByTIme : MonoBehaviour {

	public float lifetime;

	void Start () 
	{
		Destroy (gameObject, lifetime);
	}

}
