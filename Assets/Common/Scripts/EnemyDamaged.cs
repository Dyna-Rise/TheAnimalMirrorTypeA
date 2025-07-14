using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    public int enemyLife = 3;
    public GameObject enemyModel; // 表示/非表示を切り替える対象
    public PlayerSEPlay playerSePlay;

    //コルーチン連続発生の防止フラグとサウンド、エフェクト追加
    Coroutine damageStart;
    public GameObject deathEffectPrefab;
    public GameObject damageEffectPrefab;

    //アイテムドロップ
    public GameObject[] items;
    //ドロップ率
    public int itemDropRate = 50;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") || collision.gameObject.CompareTag("PlayerTackle"))
        {
            //コルーチンが走っている間は無効
            if (damageStart == null)
            {
                damageStart = StartCoroutine(DamageStart());
            }          
        }
    }

    IEnumerator DamageStart()
    {
        playerSePlay.PlaySePitchRdm("damage_hit");
        enemyLife--;

        //Lifeが0になったら消滅
        if (enemyLife <= 0)
        {
            //後に残る死亡エフェクト（エフェクトに音がついている）
            Instantiate(deathEffectPrefab, transform.position + new Vector3(0,0.5f,0), Quaternion.identity);

            //アイテムが落ちるかどうか
            int rand = Random.Range(1, 101);
            if(rand <= itemDropRate)
            {
                //どのアイテムをドロップするか
                int itemRand = Random.Range(0, items.Length);
                Instantiate(items[itemRand],transform.position + new Vector3(0,0.5f,0), Quaternion.identity);
            }


            //消滅
            Destroy(gameObject);
        }

        //エフェクト追加
        Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);

        // 点滅開始
        StartCoroutine(BlinkEffect());

        yield return new WaitForSeconds(2.0f); //次のダメージまでのインターバル
        damageStart = null; //コルーチンを解除して次のダメージ受け入れ可能にする
    }

    //点滅
    IEnumerator BlinkEffect(float blinkTime = 1.0f, float interval = 0.1f)
    {
        float timer = 0f;
        while (timer < blinkTime)
        {
            enemyModel.SetActive(false);
            yield return new WaitForSeconds(interval);
            enemyModel.SetActive(true);
            yield return new WaitForSeconds(interval);
            timer += interval * 2;
        }
    }

}
