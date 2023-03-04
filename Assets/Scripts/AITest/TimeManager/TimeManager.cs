using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // The time multiplier for speeding up or slowing down the game time 加速或减缓游戏时间的时间倍增器
    public float timeMultiplier = 1f;

    // The start time of the game 游戏开始时间
    private DateTime startTime;

    private void Start()
    {
        // Set the start time to the current time when the game starts 将开始时间设置为游戏开始的当前时间
        startTime = DateTime.Now;
    }

    public float GetGameTime()
    {
        // Calculate the game time based on the elapsed real time and the time multiplier 根据经过的实时时间和时间乘数计算游戏时间
        var elapsedTime = (float) (DateTime.Now - startTime).TotalSeconds;
        return elapsedTime * timeMultiplier;
    }
}