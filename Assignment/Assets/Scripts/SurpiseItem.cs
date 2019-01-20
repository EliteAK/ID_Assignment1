using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurpiseItem : MonoBehaviour {
    public GameObject popupMenu;
    public GameObject examine;
    bool timer = false;
    public float timerDelay = 4f;

    private AudioSource source;
    [SerializeField] private AudioClip clip;

    void OnTriggerEnter(Collider col)
    {
        source = col.GetComponent<AudioSource>();
        source.PlayOneShot(clip);
        Time.timeScale = 0f;
        popupMenu.SetActive(true);
        examine.SetActive(false);       
    }

    public void Pick()
    {
        if (Random.value < 0.25f)
        {
            HUD_Controller.score += 200;
        }
        else if (Random.value < 0.5f)
        {
            HUD_Controller.score -= 200;
        }
        else if (Random.value < 0.75f)
        {
            HUD_Controller.score = +50;
        }
        else
        {
            HUD_Controller.score -= 50;
        }
        popupMenu.SetActive(false);
        Time.timeScale = 1f;
        Destroy(gameObject);
    }

    public void Drop()
    {
        popupMenu.SetActive(false);
        timer = true;
        gameObject.GetComponent<Collider>().enabled = false;
        Time.timeScale = 1f;
    }

    void Start ()
    {
        popupMenu.SetActive(false);
        examine.SetActive(false);
    }

    void Update ()
    {
        if (timer)
        {
            if (timerDelay >= 8)
            {
                timer = false;
                gameObject.GetComponent<MeshCollider>().enabled = true;
                timerDelay = 4f;
            }
            else
            {
                timerDelay += Time.deltaTime;
            }
        }
    }
}
