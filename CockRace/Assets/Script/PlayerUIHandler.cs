using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI cockroaches;


    public void toggleUI()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
        
    }

    public void changeScore(int value)
    {
        highscore.text = "Score: " + value.ToString();
    }


    public void UpdateHP(int current)
    {
        cockroaches.text = "Cockroaches: " + current.ToString();
    }
}
