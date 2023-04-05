using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int collectedCoin;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            DestroyImmediate(this);
        }
    }

    private static GameManager instance;
    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }

    public void Start()
    {
        UIManager.MyInstance.UpdateCoinUI(collectedCoin);
    }

    public void AddCoins(int _coins)
    {
        collectedCoin += _coins;
        UIManager.MyInstance.UpdateCoinUI(collectedCoin);
    }

    public void Finish()
    {
        if (collectedCoin > 70)
        {
            SceneManager.LoadScene("easy");
        }
        else
        {
            SceneManager.LoadScene("level2");
        }
    }
}
