using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIController : MonoBehaviour
{
    public Text levelText;
    public Text experienceText;
    public Text coinsText;
    public Text gameTimeText;

    private void Update()
    {
        var player = FindObjectOfType<Player>();
        if (player != null)
        {
            levelText.text = "Level: " + player.level;
            experienceText.text = "Experience: " + player.experiencePoints;
            coinsText.text = "Coins: " + player.coins;
        }

        var timeManager = FindObjectOfType<TimeManager>();
        if (timeManager != null)
        {
            var gameTime = timeManager.GetGameTime();
            gameTimeText.text = "Game Time: " + TimeSpan.FromSeconds(gameTime).ToString(@"hh\:mm\:ss");
        }
    }
}