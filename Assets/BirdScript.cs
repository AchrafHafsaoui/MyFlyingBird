using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D shield;
    public float flapStrength;
    public LogicScript logic;
    public static bool alive;
    public AudioSource flapAudio;
    public AudioSource shieldAudio;
    private Rigidbody2D rb;
    private bool activeShield;
    private float timer = 0;
    private Vector2 initialPos;
    private bool visible;


    // Start is called before the first frame update
    void Start()
    {
        visible = true;
        alive = true;
        rb = GetComponent<Rigidbody2D>();
        initialPos = rb.position;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        activeShield = PlayerPrefs.GetInt("ShieldsCount", 0) > 0;
        if (activeShield) PlayerPrefs.SetInt("ShieldsCount", PlayerPrefs.GetInt("ShieldsCount", 0) - 1);
        else shield.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (!visible)
            {
                revive();
                visible = true;
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && alive)
                {
                    rb.velocity = Vector2.up * flapStrength;
                    shield.velocity = Vector2.up * flapStrength;
                    flapAudio.Play();
                }
            }
        }
        else if (timer < 3)
        {
            if (timer == 0) logic.reviveVisibility(true);
            timer += Time.deltaTime;
        }
        else if (!alive) Die();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (activeShield)
        {
            activeShield = false;
            shieldAudio.Play();
            shield.GetComponent<SpriteRenderer>().enabled = false;
        }
        else alive = false;
    }

    void OnBecameInvisible()
    {
        alive = false;
        activeShield = false;
        visible = false;
        shield.GetComponent<SpriteRenderer>().enabled = false;
    }

    void Die()
    {
        logic.reviveVisibility(false);
        logic.gameOverVisibility(true);
        PipeMoveScript.resetSpeed();
    }

    public void revive()
    {
        if (logic.getCoins() >= 200)
        {
            logic.addCoins(-200);
            logic.reviveVisibility(false);
            rb.position = initialPos;
            rb.velocity = Vector2.up * flapStrength;
            alive = true;
        }
    }
}