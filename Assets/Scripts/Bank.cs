using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TMP_Text scoreText;
    public int CurrentBalance { get { return currentBalance; }  }

    void Awake()
    {
        currentBalance = startingBalance;
        scoreText.text = $"Gold: {currentBalance.ToString()}";
    }

    public void Deposit(int amount)
    {
        currentBalance += Math.Abs(amount);
        UpdateScore();
    }

    public void Withdrawal(int amount)
    {
        currentBalance -= Math.Abs(amount);
        UpdateScore();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateScore()
    {
        scoreText.text = $"Gold: {currentBalance.ToString()}";
    }
}
