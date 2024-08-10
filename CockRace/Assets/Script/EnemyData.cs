using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyData : MonoBehaviour , IDamagable
{
    SpriteRenderer spriteRenderer;
    public Sprite idleFace;
    public Sprite angerFace;
    public Sprite deadFace;


    public int GivenHighscore;
    public UIEnemy ui;
    public GameObject visionCircle;
    public int MaxHP = 10;
    int currentHp;
    public PlayerData player;
    public StateManager stateManager;
    public float speed;
    public Waypoint waypoint;
    bool isDead=false;
    bool chasingPlayer;


    public int HP{ get { return currentHp; } set { 
            currentHp = value;
            ui.ChangeHP(currentHp);
        } }

    public bool IsChasingPlayer {  get { return chasingPlayer; } set { chasingPlayer = true; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HP = MaxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = idleFace;
        currentHp = MaxHP;

    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerData>()){
            GetDamage(player.HP, player);
            player.OnDamageRecieved(currentHp, Vector3.Normalize(collision.transform.position - transform.position));
        }
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



    public void GetDamage(int value, PlayerData player)
    {
            currentHp -= value;
            if (currentHp <= 0)
        {
            currentHp = 0;
            isDead = true;
            visionCircle.SetActive(false);
            player.highScore += GivenHighscore;
        }

    }

    public void GiveHP(int value)
    {
        currentHp += value;
        visionCircle.SetActive(true);
    }
}
