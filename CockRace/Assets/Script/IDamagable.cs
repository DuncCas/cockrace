using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    void GetDamage(int value, PlayerData player);

    void GiveHP(int value);
}
