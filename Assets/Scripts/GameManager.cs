using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject newGameButton;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] GameObject player;
    [SerializeField] VehicleCreator creator;
    [SerializeField] MusicManager music;
    [SerializeField] float speedVehicle;
    [SerializeField] float minSpawnTime = 0.6f;
    [SerializeField] float maxSpawnTime = 2.0f;
    [SerializeField] float speedIncreaseValue = 0.3f;
    [SerializeField] List<Transform> spawnPoint = new List<Transform>();
    private int score = 0;
    private int bestScore = 0;
    private int lastScore = 0;
    public List<GameObject> poolVehicle;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    public float GetSpeedObstacle()
    {
        return speedVehicle;
    }
    private void Start()
    {
        LoadScore();
        bestScoreText.text = "Best: " + bestScore;
        scoreText.text = "Last: " + lastScore;
        poolVehicle = creator.CreatePoolingVehicle();
    }
    IEnumerator SpawnVehicle()
    {
        while (true)
        {
            float randWaitTime = Random.Range(minSpawnTime, maxSpawnTime);
            newVehicle();
            yield return new WaitForSeconds(randWaitTime);
        }
        
    }
    int randPosition()
    {
        int position = Random.Range(0, spawnPoint.Count);
        return position;  
    }
    void newVehicle()
    {
        GameObject randVehicle;
        Vehicle vehicle;
        for(int i = 0; i < poolVehicle.Count; i++)
        {
            int randNumber = Random.Range(0, poolVehicle.Count);
            randVehicle = poolVehicle[randNumber];

            if (!randVehicle.activeSelf)
            {
                randVehicle.transform.position = spawnPoint[randPosition()].position;
                randVehicle.SetActive(true);
                vehicle = randVehicle.GetComponent<Vehicle>();
                vehicle.SetSpeed(speedVehicle);
                break;
            }     
        }
    }
    public void ScoreUp()
    {
        speedVehicle += speedIncreaseValue;
        score++;
        music.ActivateLevelMusic(score);
        ReductionOfSpawnTime();
        scoreText.text = "Score: " + score;
    }
    void ReductionOfSpawnTime()
    {
        float minimumTimeLimit = 0.1f;
        float timeChangeValue = 0.01f;
        if (minSpawnTime > minimumTimeLimit)
            minSpawnTime -= timeChangeValue;
        if(maxSpawnTime > 2 * minimumTimeLimit)
            maxSpawnTime -= timeChangeValue * 2;
    }
    public void GameStart()
    {
        StartCoroutine(SpawnVehicle());
        playButton.SetActive(false);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        playButton.SetActive(false);
        player.SetActive(true);
        bestScoreText.text = "";
        scoreText.text = "";     
    }

    public void EndGame()
    {
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        newGameButton.SetActive(true);
        music.playDeadMusic();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
        SaveScore();
        score = 0;
    }

    public int GetBestScore()
    {
        return bestScore;
    }
    public int GetLastScore()
    {
        return lastScore;
    }
    public void SaveScore()
    {
        lastScore = score;
        if (score > bestScore)
            bestScore = score;
        SaveSystem.SaveScore();
    }
    public void LoadScore()
    {
        ScoreData data = SaveSystem.LoadScore();
        if(data != null)
        {
            bestScore = data.bestScore;
            lastScore = data.lastScore;
        }
        else
        {
            bestScore = 0;
            lastScore = 0;
        }
        
    }
}
