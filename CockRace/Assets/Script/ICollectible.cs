using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible 
{
    public void OnCollected();

    public void OnPlayerInteraction(GameObject player);

    public void OnPlayerStopInteraction();
}
