using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnNormal : MonoBehaviour
{
    public float returnTime = 20.0f;
    public PlayerChange playerChange;
    float currentTime;
    public bool isCountDown;
    public PlayerSEPlay playerSePlay;

    public TriggerJudge triggerJudge;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = returnTime;    
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountDown) return;

        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && (GameController.gameState == GameState.playing))
        {
            isCountDown = false;
            currentTime = returnTime;
            playerChange.playerForm = PlayerForm.Normal;
            playerChange.ChangeForm(playerChange.playerForm);

            TriggerJudge.isApproach = false;
            triggerJudge.enemyType = EnemyType.None;

            //playerSePlay.PlaySe("kaijyo");
            GameController.isPlayerHide = false;
        }
    }
}
