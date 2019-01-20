using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Places : MonoBehaviour {

    HUD_Controller HC;
    private AudioSource source;
	[SerializeField] private AudioClip clip;

    void Start()
    {
        GameObject ccgo = GameObject.Find("HUDController");
        HC = ccgo.GetComponent<HUD_Controller>();
    }

    void OnTriggerEnter (Collider col)
	{
        HUD_Controller.score += 100;
        HC.getPlaces(gameObject);
		Debug.Log ("You've visted " + gameObject.name);
		source = col.GetComponent<AudioSource> ();
		source.PlayOneShot(clip);
		Destroy(gameObject);
	}
}