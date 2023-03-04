using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // The current level of the player 玩家当前的等级
    public int level = 1;

    // The current experience points of the player 玩家当前的经验值
    public int experiencePoints = 0;

    // The current coins of the player 玩家当前的硬币
    public int coins = 0;

    // The time when the player left the game last time 玩家上次离开游戏的时间
    private DateTime lastPlayedTime;

    void Start()
    {
        // Load the last played time from the player prefs 从player prefs加载最后的播放时间
        var lastPlayedTimeString = PlayerPrefs.GetString("LastPlayedTime", "");
        if (!string.IsNullOrEmpty(lastPlayedTimeString))
        {
            lastPlayedTime = DateTime.Parse(lastPlayedTimeString);
        }
        else
        {
            lastPlayedTime = DateTime.Now;
        }

        // Calculate the elapsed time and add the corresponding experience points and coins 计算经过的时间，并添加相应的经验值和金币
        var elapsedTime = (float) (DateTime.Now - lastPlayedTime).TotalSeconds;
        experiencePoints += (int) (elapsedTime * level);
        coins += (int) (elapsedTime * 10f);

        // Save the current time to player prefs 将当前时间保存到player prefs
        PlayerPrefs.SetString("LastPlayedTime", DateTime.Now.ToString());
    }

    void Update()
    {
        // Save the current time to player prefs every 60 seconds 每隔60秒将当前时间保存到player prefs
        if (Time.time % 60f < Time.deltaTime)
        {
            PlayerPrefs.SetString("LastPlayedTime", DateTime.Now.ToString());
        }

        // Increase the experience points and coins every frame based on the time multiplier 基于时间乘数增加每一帧的经验值和金币
        var timeMultiplier = FindObjectOfType<TimeManager>().timeMultiplier;
        experiencePoints += (int) (Time.deltaTime * level * timeMultiplier);
        coins += (int) (Time.deltaTime * 10f * timeMultiplier);
    }
}