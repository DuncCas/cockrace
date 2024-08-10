using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    string id = "Attack";

    public EnemyData _enemyData;
    bool isMoving;
    public IdleState idleState;
    public DeathState deathState;


    public override string GetID() {  return id; }

    public override State RunBehaviour()
    {
        if (_enemyData.HP <= 0)
        {
            _enemyData.OnChangeState("Dead");
            deathState.StartTimer();
            return deathState;
        }

        if (!_enemyData.IsChasingPlayer)
        {
            _enemyData.OnChangeState(" ");
            return idleState;
        }

        _enemyData.transform.position += (Vector3.Normalize(_enemyData.player.transform.position - _enemyData.transform.position)) * _enemyData.speed * Time.deltaTime;

        return this;
    }
}
