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
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] int hp;

    [SerializeField] TextMeshProUGUI displayBalance;

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDislay();

    }

    public void Withdraw(int amount, bool isGold)
    {
        if (isGold)
        {
            currentBalance -= Mathf.Abs(amount);
        }
        else if (!isGold)
        {
            hp -= 1;
        }

        UpdateDislay();

        if (hp < 1)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
       Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDislay()
    {
        displayBalance.text = "Gold: " + currentBalance + " HP: " + hp;
    }
}
