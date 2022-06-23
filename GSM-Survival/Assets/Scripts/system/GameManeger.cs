using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManeger : MonoBehaviour
{
    public TMP_Text timeText;
    public GameObject clearText;
    public GameObject overText;
    public GameObject enemy;
    public GameObject menuSet;

    public float surviveTime;
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveTime -= Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        }
        if(surviveTime <= 0)
        {
            clearText.SetActive(true);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                menuSet.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("ChoseCharacter");
    }

    public void change()
    {
        SceneManager.LoadScene("Game");
    }

    public void EndGame()
    {
        isGameover = true;
        overText.SetActive(true);
        enemy.SetActive(false);
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }
    public void Continue()
    {
        menuSet.SetActive(false);
    }
}
