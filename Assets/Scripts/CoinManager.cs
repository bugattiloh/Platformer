using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    private int _coins;
  
    public Text scoreCounter;

    private void Start()
    {
        _coins = PlayerPrefs.GetInt("Coins", _coins);
        scoreCounter.text = _coins.ToString();
    }

    public void AddCoin()
    {
        _coins++;
        scoreCounter.text = _coins.ToString();
    }

    public void Finish()
    {
        PlayerPrefs.SetInt("Coins", _coins);
        _coins = 0;
    }
}