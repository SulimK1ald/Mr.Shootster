using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour
{
    public GameObject bullet;
    public int quantityBullets = 10;
    public Text bulletsText;
    public Transform spawnPoint;
    public Transform spawnPoint2;

    //public bool[] guns = new bool[4];

    public float timeBtwShots;
    public float startTimeBtwShots;


    void Start()
    {
        bulletsText.text = "Патроны: " + quantityBullets.ToString();
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (quantityBullets >= 1 && bullet != null)
                {
                    quantityBullets--;
                    bulletsText.text = "Патроны: " + quantityBullets.ToString();

                    if (spawnPoint != null)
                    {
                        Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                        timeBtwShots = startTimeBtwShots;
                    }

                    if (spawnPoint2 != null)
                    {
                        Instantiate(bullet, spawnPoint2.position, spawnPoint2.rotation);
                        timeBtwShots = startTimeBtwShots;
                    }
                }
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
