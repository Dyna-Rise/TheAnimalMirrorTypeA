using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormDamaged : MonoBehaviour
{   
    public PlayerChange playerChange;
    public TriggerJudge triggerJudge;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") && GameController.gameState == GameState.playing)
        {
            playerChange.playerForm = PlayerForm.Normal;
            playerChange.ChangeForm(playerChange.playerForm);
            triggerJudge.enemyType = EnemyType.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") && GameController.gameState == GameState.playing)
        {
            playerChange.playerForm = PlayerForm.Normal;
            playerChange.ChangeForm(playerChange.playerForm);
            triggerJudge.enemyType = EnemyType.None;
        }

        if (other.gameObject.CompareTag("Dead"))
        {
            playerChange.playerForm = PlayerForm.Normal;
            playerChange.ChangeForm(playerChange.playerForm);
        }
    }
}
