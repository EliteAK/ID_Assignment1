using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour {

	private AudioSource source;
	[SerializeField] private AudioClip clip;


	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("You've visted " + gameObject.name);
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);
		Destroy(gameObject);
	}
}