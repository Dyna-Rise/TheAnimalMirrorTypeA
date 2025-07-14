using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public Slider bossSlider;
    public EnemyDamaged bossDamaged;

    int currentBossLife;

    public GameObject bossLifePanel;

    public GameObject gameClearImage;

    // Start is called before the first frame update
    void Start()
    {
        currentBossLife = bossDamaged.enemyLife;
        bossSlider.maxValue = currentBossLife;
        bossSlider.value = currentBossLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBossLife != bossDamaged.enemyLife)
        {
            currentBossLife = bossDamaged.enemyLife;
            bossSlider.value = currentBossLife;


            if (bossDamaged.enemyLife <= 0) Invoke("HiddenBossLife",2.0f);
        }
    }

    void HiddenBossLife()
    {
        bossLifePanel.SetActive(false); //Lifeは非表示
        gameClearImage.SetActive(true); //GameClearの文字を表示
        StartCoroutine(ToTitle());
    }

    IEnumerator ToTitle()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Title");
    }
}
