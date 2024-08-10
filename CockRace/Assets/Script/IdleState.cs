using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class IdleState : State
{
    string id = "Idle";

    public EnemyData _enemyData;
    public Vector3 currentPositionToGo;
    public bool isMoving;
    [SerializeField]float waitTimer;
    public float maxWaitTimer;
    public AttackState attackState;


    public override string GetID() { return id; }


    public override State RunBehaviour()
    {
        if (_enemyData.IsChasingPlayer)
        {
            _enemyData.OnChangeState("Interacting");
            return attackState;
        }

        if (isMoving)
        {
            if ((currentPositionToGo.x - 0.5 < _enemyData.transform.position.x) && currentPositionToGo.y - 0.5 < _enemyData.transform.position.y)
            {
                waitTimer = maxWaitTimer;
                isMoving = false;
            }
            else
            {
                _enemyData.transform.position += (Vector3.Normalize(currentPositionToGo - _enemyData.transform.position)) * _enemyData.speed * Time.deltaTime;
            }

        }
        else
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                currentPositionToGo=SetWaypoint(_enemyData.transform.position);
                isMoving = true;
            }
        }
        
        return this;
    }

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
