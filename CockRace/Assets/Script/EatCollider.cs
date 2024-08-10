using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCollider : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.GetComponent<Food>() && !playerController.eating)
        {
            Debug.Log("food");
            playerController.closeFood= collision.GetComponent<Food>();
            playerController.ActivateEatInput();
            //showUI
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Food>())
        {
            playerController.closeFood = null;
            playerController.DeActivateEatInput();
            //hideUI
        }
    }

}
