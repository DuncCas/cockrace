using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    public TextMeshProUGUI hp;
    public EnemyData enemyData;

    public void ChangeHP(int value)
    {

            hp.text = enemyData.HP.ToString();

    }



}
