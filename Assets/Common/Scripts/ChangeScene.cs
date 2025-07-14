using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName;
    public bool isBoss; //ボスシーンへのリトライかどうか

    public void LoadScene()
    {
        //ボスシーンへのリトライ以外
        if (!isBoss) { 
            GameController.coinPoint = 0; //コインはリセット
        }

        SceneManager.LoadScene(sceneName);
    }
}
