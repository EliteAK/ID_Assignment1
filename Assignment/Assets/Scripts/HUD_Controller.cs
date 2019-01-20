using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    public Text usernameText;
    public Text stepsText;
    public Text scoreText;
    public Text bulletsText;
    public Text dynamiteText;
    public Text bottleText;
    public static int Bullets;
    public static int Dynamite;
    public static int Bottles;
    public static float score;
    public Image healthBar;
    public static float health = 1f;
    public Text btText;
    public Toggle btToggle;
    public Text gmText;
    public Toggle gmToggle;
    public Text bcText;
    public Toggle bcToggle;
    public Text stText;
    public Toggle stToggle;
    public Text ttText;
    public Toggle ttToggle;


    void Start()
    {

    }

    void Update()
    {
        if (score <= 0f)
        {
            score = 0;
        }
        usernameText.text = MenuController.username;
        bulletsText.text = "" + Bullets;
        bottleText.text = "" + Bottles;
        dynamiteText.text = "" + Dynamite;
        scoreText.text = score.ToString("F0");
        healthBar.fillAmount -= 0.02f * Time.deltaTime;
        health = healthBar.fillAmount;
        stepsText.text = PlayerController.steps.ToString("F0");
    }

    public void Reset()
    {
        score = 0f;
        PlayerController.steps = 0f;
        Bullets = 0;
        Dynamite = 0;
        Bottles = 0;
    }

    public void IncrementCount(GameObject go)
    {
        if (go.name.Contains("Bullet"))
        {
            Bullets++;
            score += 10;
        }
        else if (go.name.Contains("Bottle"))
        {
            Bottles++;
            score += 10;
        }
        else if (go.name.Contains("Dynamite"))
        {
            Dynamite++;
            score += 10;
        }
    }

    public void getPlaces(GameObject place)
    {
        if (place.name.Contains("Big Town"))
        {
            btToggle.GetComponent<Toggle>().isOn = true;
            btText.GetComponent<Text>().color = Color.black;
        }
        else if (place.name.Contains("Gold Mine"))
        {
            gmToggle.GetComponent<Toggle>().isOn = true;
            gmText.GetComponent<Text>().color = Color.black;
        }
        else if (place.name.Contains("Bandits Camp"))
        {
            bcToggle.GetComponent<Toggle>().isOn = true;
            bcText.GetComponent<Text>().color = Color.black;
        }
        else if (place.name.Contains("Small Town"))
        {
            stToggle.GetComponent<Toggle>().isOn = true;
            stText.GetComponent<Text>().color = Color.black;
        }
        else if (place.name.Contains("Travellers Tent"))
        {
            ttToggle.GetComponent<Toggle>().isOn = true;
            ttText.GetComponent<Text>().color = Color.black;
        }
    }




}