using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class MenuController : MonoBehaviour {

    public ScoreData[] highScoreArray;
    public InputField usernameInput;
    public static string username;
    public Button playButton;
    public GameObject HUD;
    public GameObject endMenu;
    public GameObject startMenu;
    public GameObject menuCamera;
    public Text playerScore;
    public Text usernameDisplay;
    public Text highScoreNameDispaly;
    public Text highscoreDisplay;
    public GameObject newHighscore;
    public GameObject notHighscore;
    public bool characterSelected = false;
    public int characterNum;

    public void PlayGame()
    {
        Time.timeScale = 1f;
        username = usernameInput.text;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        menuCamera.SetActive(true);
        HUD.SetActive(false);
        endMenu.SetActive(true);
        usernameDisplay.text = username;
        playerScore.text = HUD_Controller.score.ToString("F0");
        if (HUD_Controller.score >= highScoreArray[0].highScore)
        {
            newHighscore.SetActive(true);
            notHighscore.SetActive(false);
            highScoreArray[0].highScore = HUD_Controller.score;
            highScoreArray[0].playerName = username;
            SaveData();
        }
        else
        {
            newHighscore.SetActive(false);
            notHighscore.SetActive(true);
        }
        highScoreNameDispaly.text = highScoreArray[0].playerName;
        highscoreDisplay.text = highScoreArray[0].highScore.ToString("F0");
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


	void Start ()
    {
        LoadData();
        Time.timeScale = 0f;
        menuCamera.SetActive(true);
        startMenu.SetActive(true);
        endMenu.SetActive(false);
        HUD.SetActive(false);
    }

    public void Character1()
    {
        characterNum = 1;
        characterSelected = true;
    }

    public void Character2()
    {
        characterNum = 2;
        characterSelected = true;
    }

    public void Character3()
    {
        characterNum = 3;
        characterSelected = true;
    }


    void Update () {
        if (usernameInput.text == "" || characterSelected == false)
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }
        if (HUD_Controller.health <= 0 && Time.timeScale == 1f)
        {
            EndGame();
        }
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/highScore.dat");
        bf.Serialize(fs, highScoreArray);
        fs.Close();
        Debug.Log("Data Saved.");
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/highScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/highScore.dat", FileMode.Open);
            highScoreArray = (ScoreData[])bf.Deserialize(fs);
            fs.Close();
            Debug.Log("Data Loaded.");
        }
        else
        {
            Debug.LogError("File you are trying to load from is missing");
        }

    }
}
