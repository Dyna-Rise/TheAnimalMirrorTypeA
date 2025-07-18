using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDShooter : MonoBehaviour
{
    const int MaxShootStock = 5;
    const float RecoverySeconds = 1.5f; // 回復時間定数

    public static int currentShootStock = MaxShootStock;
    //AudioSource shotSound;

    public GameObject carrotPrefab; // Carrotプレハブ
    public float shootSpeed;

    public GameObject playerD;
    PlayerDController playerDController;
    Animator anime;

    bool inAttack; // 攻撃中かどうかのフラグ

    void OnEnable()
    {
        currentShootStock = MaxShootStock;
        inAttack = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerDController = playerD.GetComponent<PlayerDController>();
        anime = playerD.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameState != GameState.playing) return;

        if (Input.GetMouseButtonDown(0)) // もしも左クリックが押されたら
        {
            if (playerDController.IsGrounded()) ShootAttack(); // シュートメソッド
        }
    }

    void ShootAttack()
    {
        // 残弾数がなくて攻撃中ならシュートしない
        if (currentShootStock <= 0 || inAttack) return;

        anime.SetTrigger("attack");

        // プレハブからCarrotオブジェクトを生成
        GameObject carrot = Instantiate(
            carrotPrefab,
            transform.position,
            Quaternion.identity
        );

        // CarrotオブジェクトのRigidbodyを取得し力を加える
        Rigidbody carrotRigidBody = carrot.GetComponent<Rigidbody>();
        carrotRigidBody.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);

        Destroy(carrot, 1.0f);

        // currentShootStockを消費
        ConsumePower();

        // サウンドを再生
        //shotSound.Play();
    }

    void ConsumePower()
    {
        // currentShootStockを消費すると同時に回復のカウントをスタート
        inAttack = true;
        StartCoroutine(ShootStart());

        currentShootStock--;
        StartCoroutine(ShootStockRecovery());
    }

    IEnumerator ShootStart()
    {
        yield return new WaitForSeconds(0.2f);
        inAttack = false;
    }

    IEnumerator ShootStockRecovery()
    {
        // 一定秒数待った後にcurrentShootStockを回復
        yield return new WaitForSeconds(RecoverySeconds);
        currentShootStock++;
    }
}
