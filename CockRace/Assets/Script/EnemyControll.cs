using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public int hp;
    ENEMY_STATE currentState;
    public int respawnTime;

}









public enum ENEMY_STATE
{
    IDLE,
    ATTACKING,
    DEATH
}