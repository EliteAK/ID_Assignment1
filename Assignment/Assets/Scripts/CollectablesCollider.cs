using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesCollider : MonoBehaviour {

	CollectablesController cc;


	private AudioSource source;
	[SerializeField] private AudioClip clip;

	void Start()
	{
		GameObject ccgo = GameObject.Find ("Collectables Controller");
		cc = ccgo.GetComponent<CollectablesController> ();
	}

	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("You've collected a " + gameObject.name);
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);
		cc.IncrementCount (gameObject);
		Destroy(gameObject);
	}
}
