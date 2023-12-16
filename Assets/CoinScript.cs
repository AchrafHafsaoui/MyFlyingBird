using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public Text coinsText;
    private int numberOfCoins;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        numberOfCoins=int.Parse(coinsText.text);
    }

    void Update()
    {   
        if(int.Parse(coinsText.text)>numberOfCoins){
            rb.velocity=Vector2.up*15;
            numberOfCoins=int.Parse(coinsText.text);
        }
    }
}
