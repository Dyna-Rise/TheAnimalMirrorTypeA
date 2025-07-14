using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUI : MonoBehaviour
{
    public GameObject[] bulletPanels;
    int currentStock;

    // Start is called before the first frame update
    void Start()
    {
        currentStock = PlayerDShooter.currentShootStock;
        BulletDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStock != PlayerDShooter.currentShootStock)
        {
            currentStock = PlayerDShooter.currentShootStock;
            BulletDisplay();
        }
    }

    void BulletDisplay()
    {
        //一旦全消去
        for(int i = 0; i < bulletPanels.Length; i++)
        {
            bulletPanels[i].SetActive(false);
        }

        //弾がある分だけ表示
        for(int i = 0;i < currentStock; i++)
        {
            bulletPanels[i].SetActive(true);
        }
    }
}
