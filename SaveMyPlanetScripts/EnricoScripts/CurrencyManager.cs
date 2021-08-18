using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] int coinValueFirstHalf;
    [SerializeField] int coinValueSecondtHalf;
   
    public int coins = 0;
    public int secondCounter = 0; // Second count

    protected float Timer;
    private Healthbar pollution;
    public Text coinsText;

    void Start()
    {
        pollution = FindObjectOfType<Healthbar>();//
    }

    void Update()
    {
        GiveCoins();
        coinsText.text = coins.ToString();
    }

    private void GiveCoins()
    {
        Timer += Time.deltaTime;

        if (Timer >= secondCounter)
        {
            if (/*pollution.currentHealth != null &&*/ pollution.currentHealth <= pollution.maxHealth / 2)
            {
                Timer = 0f;
                coins += coinValueFirstHalf;
            }
            if (pollution.currentHealth > pollution.maxHealth / 2 && pollution.currentHealth < pollution.maxHealth)
            {
                Timer = 0f;
                coins += coinValueSecondtHalf;
            }
        }
    }

    //void OnGUI()
    //{
    //    GUI.Box(new Rect(30, 10, 150, 30), "Coins: " + coins.ToString()); // change this to Canvas

    //}
}
