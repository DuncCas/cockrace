using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    int MaxGameScore;
    static GameLogic instance;
    public GameObject player;
    public Transform playerSpawnPoint;
    PlayerInput input;
    public UIHandler ui;
    public List<GameObject> cats;
    public List<GameObject> rats;
    public List<GameObject> foods;
    public List<GameObject> traps;
    public Transform[] spawnPoints;


    private void Awake()
    {
        instance = this;
        input = player.GetComponent<PlayerInput>();
        Time.timeScale = 0;

    }


    public void StartGame()
    {
        ui.hideCurrentCanvas();
        foreach (GameObject cat in cats)
        {
            cat.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            cat.SetActive(true);
        }
        foreach (GameObject rat in rats)
        {
            rat.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            rat.SetActive(true);
        }


        foreach (GameObject food in foods)
        {
            food.GetComponent<Food>().GameManager = this;
            food.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            food.SetActive(true);
        }

        foreach (GameObject trap in traps)
        {
            trap.GetComponent<Trap>().gameLogic = this;
            trap.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            trap.SetActive(true);
        }

        // farlo per tutti gli altri

        player.GetComponent<PlayerData>().GameManager = this;
        player.GetComponent<PlayerData>().highScore = 0;
        player.transform.position = playerSpawnPoint.position;
        PlayerData pd = player.GetComponent<PlayerData>();
        pd.ui.toggleUI();
        pd.HP = pd.hp;
        pd.ui.UpdateHP(pd.hp);
        Time.timeScale = 1;

    }

    public static void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    void doExitGame() { Application.Quit(); }

    public void SpawnEntity(GameObject entity, Vector3 previousPos)
    {
        Vector3 newPos = previousPos;
        while (previousPos == newPos)
        {
            newPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        }
        entity.transform.position= newPos;
        entity.SetActive(true);
    }


    public void EndGame()
    {
        Time.timeScale = 0;
        ui.OpenGameOverCanvas();
    }








}
