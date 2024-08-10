using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerData : MonoBehaviour, IDamagable
{

    SpriteRenderer spriteRenderer;
    public Sprite idleFace;
    public Sprite angerFace;
    public Sprite deadFace;

    [SerializeField] GameLogic gameLogic;
    public int hp = 5;
    [SerializeField] int currentHP;
    [SerializeField] int highScore;
    [SerializeField] PlayerController controller;
    public int growthMultiplier = 2;
    public int startingGrowthCheck = 20;
    public int maxGrowthCheck = 5;
    public PlayerUIHandler ui;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = idleFace;
    }

    public void OnChangeState(string state)
    {
        switch (state)
        {
            case "Interacting":
                ChangeFace(angerFace);
                break;
            case "Dead":
                ChangeFace(deadFace);
                break;
            default:
                ChangeFace(idleFace);
                break;
        }
    }


    private void ChangeFace(Sprite face)
    {
        Sprite sp = spriteRenderer.sprite;
        if (sp != face)
        {
            sp = face;
        }
    }

    public int HP { 
        get { return currentHP; } set { 
        
            currentHP = value;
            ui.UpdateHP(currentHP);
        }
            
    }

    public GameLogic GameManager { get {return gameLogic; } set { gameLogic = value; } }

    public void GiveScore(int value)
    {
        highScore += value;
        ui.changeScore(value);
    }

    public void RemoveScore(int value)
    {
        highScore -= value;
        if (highScore < 0)
        {
            highScore = 0;
        }
        ui.changeScore(value);
    }


    public void OnDamageRecieved(int value, Vector3 dir)
    {
        GetDamage(value);
        controller.OnPushPlayer(dir);
    }

    public void GetDamage(int value)
    {
        if (currentHP == 1)
        {
            controller.Death();
            currentHP = 0;
        }
        else
        {
            currentHP -= value;
            if (currentHP <= 1)
                currentHP = 1;
        }

        ui.UpdateHP(currentHP);
        
    }

    public void GiveHP(int value)
    {
        currentHP += value;
        ui.UpdateHP(currentHP);
    }

    public void MultiplyHP(int multiplier)
    {
        currentHP *= multiplier;
        ui.UpdateHP(currentHP);
    }
}
