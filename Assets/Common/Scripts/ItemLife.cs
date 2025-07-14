using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    public int healPower = 1;
    public GameObject lifeEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //体力回復
            GameController.playerLife += healPower;

            //エフェクト効果
            Instantiate(lifeEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}
