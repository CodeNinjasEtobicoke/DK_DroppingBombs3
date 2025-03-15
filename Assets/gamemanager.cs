using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamemanager : MonoBehaviour
{
    public GameObject title;
    private spawner spawner;
    private Vector2 screenBounds;
    public GameObject splash;
    [Header("Player")]
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    [Header("Score")]
    public TMP_Text scoreText;
    public int pointsWorth = 1;
    private int score;
    private void Awake()
     
    {
        spawner = GameObject.Find("B-52").GetComponent<spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        scoreText.enabled = false;
    }

    // Update is called once per frame
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
    }
    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
        }
        else 
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }
        if (Input.anyKeyDown)
        {
            spawner.active = true;
        }
        var nextBomb = GameObject.FindGameObjectsWithTag("bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y - 12))
            {
                if (gameStarted)
                {
                    score += pointsWorth;
                    scoreText.text = "Score: " + score.ToString();
                }
                Destroy(bombObject);
            }
        }
    }
    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        scoreText.enabled = true;
        splash.SetActive(false);
        score = 0;
        
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
    }
    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;
        splash.SetActive(true);
    }
}
