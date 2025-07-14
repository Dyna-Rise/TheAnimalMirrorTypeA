using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    public int point = 1;
    public GameObject coinEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //体力回復
            GameController.coinPoint += point;

            //エフェクト効果
            Instantiate(coinEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
