using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    string id = "Death";

    public EnemyData _enemyData;
    public GameObject visionCollider;
    float timerDeath;
    public float maxTimerDeath;
    public IdleState idleState;
    public AttackState attackState;


    public override string GetID()
    {
        return id;
    }

    public void StartTimer()
    {
        timerDeath = maxTimerDeath;
    }

    public override State RunBehaviour()
    {
        if (timerDeath <= 0)
        {
            if (!visionCollider.activeInHierarchy)
            {
                _enemyData.HP = _enemyData.MaxHP;
                visionCollider.SetActive(true);
                return this;
            }
            else
            {
                if (_enemyData.IsChasingPlayer)
                {
                    _enemyData.OnChangeState("Interacting");
                    return attackState;
                }
                else
                {
                    _enemyData.OnChangeState(" ");
                    _enemyData.HP = _enemyData.MaxHP;
                    return idleState;
                }
            }
        }
        timerDeath -= Time.deltaTime;
        return this;

    }
}
