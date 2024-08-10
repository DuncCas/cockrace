using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public bool trapped = false;
    float trapTimer;
    Trap currentTrap;

    Vector2 playerDir;

    public float playerSpeed = 1;

    PlayerInput input;

    Rigidbody2D rb;

    bool gettingBounced = false;
    Vector3 pushDirection;
    float bounceTimer;
    public float maxBounceTimer = 1.5f;

    public Food closeFood;
    public InputAction eatAction;
    public bool eating = false;
    float eatingTimer;

    public float bounceForce = 2;

    public PlayerData playerData;


    InputAction movementAction;
    InputAction attackAction;

    InputAction jumpAction;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        input.SwitchCurrentActionMap("Gameplay");
        movementAction = input.actions.FindAction("Movement");
        attackAction = input.actions.FindAction("Attack");
        eatAction = input.actions.FindAction("Eat");
    }


    private void Update()
    {
        if (trapped)
        {
            if (trapTimer <= 0)
            {
                currentTrap.OnCollected();
                trapped = false;
                movementAction.Enable();
                currentTrap = null;
            }else
                trapTimer -= Time.deltaTime;
        }

        if (gettingBounced)
        {
            PushPlayer();
        }
        else if (eating)
        {
            eatingTimer -= Time.deltaTime;
            if (eatingTimer <= 0)
            {
                OnFinishedEating();
            }
        }
        else
        {
            onMove();
        }
            
    }



    public void EntrapPlayer(Trap trap, int timer)
    {
        playerData.HP = playerData.HP / 2;
        currentTrap = trap;
        trapped = true;
        trapTimer= timer;
        movementAction.Disable();
    }

    public void ActivateEatInput()
    {
        eatAction.Enable();
       eatAction.started+= onEat;
    }


    public void DeActivateEatInput()
    {
        eatAction.started -= onEat;
    }


    private void OnFinishedEating()
    {
        eating = false;
        closeFood.OnCollected();
        movementAction.Enable();
    }

    void onLook()
    {
        Debug.Log("Looking");
    }
    void onMove()
    {
        playerDir = movementAction.ReadValue<Vector2>();
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (((playerDir.x < 0 && sp.flipX) || ((playerDir.x > 0) && !sp.flipX))) 
            sp.flipX = !sp.flipX;
        //Debug.Log(playerDir);
        gameObject.transform.position += new Vector3(playerDir.x, playerDir.y, 0) * playerSpeed * Time.deltaTime;
        //Debug.Log(movementAction.ReadValue<Vector2>());
    }

    void onEat(InputAction.CallbackContext context)
    {
        if (closeFood && !eating)
        {
            movementAction.Disable();
            closeFood.OnPlayerInteraction(gameObject);
            eatAction.Disable();
            playerData.OnChangeState("Interacting");
        }
    }

    public void OnPushPlayer(Vector3 direction)
    {
        pushDirection = direction;
        gettingBounced = true;
        bounceTimer = maxBounceTimer;
    }

    public void PushPlayer()
    {
        bounceTimer -= Time.deltaTime;
        if (bounceTimer > 0)
        {
            playerData.OnChangeState("Interacting");
            rb.AddForce(pushDirection * bounceForce, ForceMode2D.Impulse);
        }
        else
        {
            gettingBounced = false;
            rb.velocity = Vector2.zero;
            playerData.OnChangeState(" ");
        }
        
    }

    public void Death()
    {
        playerData.OnChangeState("Dead");
        playerData.GameManager.EndGame();
        input.SwitchCurrentActionMap("UI");
    }

    public void StartEating(int timer)
    {
        playerData.OnChangeState("Interacting");
        eatingTimer = timer;
        eating = true;
        movementAction.Enable();
    }

    public void StopEating(InputAction.CallbackContext context)
    {
        playerData.OnChangeState(" ");
        eating = false;
        movementAction.Enable();
        closeFood.OnPlayerStopInteraction();
    
    }

}
