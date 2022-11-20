using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchGuns : MonoBehaviour
{
    public GameObject[] Guns = new GameObject[5];

    public int gunCost = 10;
    public int lastGun = 0;
    public int newGun = 1;
    public Player heroScript;

    public void shoping()
    {
        if (heroScript.coins >= gunCost)
        {
            heroScript.coins = heroScript.coins - gunCost;
            gunCost = gunCost + gunCost;
            heroScript.coinsText.text = heroScript.coins.ToString();
            Guns[lastGun].SetActive(false);
            Guns[newGun].SetActive(true);
            if (newGun < 5)
            {
                lastGun++;
                newGun++;
            }
        }
    }
}
