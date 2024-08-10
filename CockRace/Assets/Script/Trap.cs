using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ICollectible
{
    public GameLogic gameLogic;
    PlayerController playerController;
    public int trapTimer = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            playerController = collision.GetComponent<PlayerController>();
            playerController.EntrapPlayer(this, trapTimer);

        }
    }



    public void OnCollected()
    {
        gameLogic.SpawnEntity(gameObject, transform.position);
    }

    public void OnPlayerInteraction(GameObject player)
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerStopInteraction()
    {
        throw new System.NotImplementedException();
    }
}
