using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Vector3 SetWaypoint(Vector3 pos)
    {
        RaycastHit2D hit;
        Vector3 newPos = new Vector3(pos.x - Random.Range(-10, 10), pos.y - Random.Range(-10, 10), 0);
        hit = Physics2D.CircleCast(newPos, 3f, Vector2.one);
        Debug.Log(hit);
        while (hit.collider.tag == "Wall")
        {
            Debug.Log(hit);
            newPos = new Vector3(pos.x - Random.Range(-10, 10), pos.y - Random.Range(-10, 10), 0);
            hit = Physics2D.CircleCast(newPos, 3f, Vector2.one);
        }
        return newPos;
    }
}
