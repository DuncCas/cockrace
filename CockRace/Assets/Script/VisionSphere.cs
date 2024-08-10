using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSphere : MonoBehaviour
{
     public EnemyData EnemyData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        EnemyData.IsChasingPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
            EnemyData.IsChasingPlayer = false;
    }

}
