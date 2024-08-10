using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Food : MonoBehaviour, ICollectible 
{
    public GameLogic gameManager;
    PlayerData playerData;
    PlayerController controller;
    public int timeToEat;
    int remainingTimeToEat;
    public int multiplierValue;


    public GameLogic GameManager {  get { return gameManager; } set { gameManager = value; } }

    public void OnCollected()
    {
        playerData.MultiplyHP(playerData.HP);
        controller = null;
        playerData = null;
        gameObject.SetActive(false);
        gameManager.SpawnEntity(gameObject, transform.position);
    }

    public void OnPlayerInteraction(GameObject player)
    {
        playerData = player.GetComponent<PlayerData>();
        controller = player.GetComponent<PlayerController>();
        if (remainingTimeToEat <= 0)
        {
            remainingTimeToEat = timeToEat;
        }
        controller.StartEating(remainingTimeToEat);
    }

    public void OnPlayerStopInteraction()
    {
        controller = null;
        playerData = null;
    }

}
