//然后，需要管理游戏中所有角色的状态。可以创建一个GameManager类，它包含一个角色列表和当前钻石数量：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 游戏中的角色列表
    public List<Character> characters;

    // 目前钻石数量
    public int diamondCount = 50;

    void Awake()
    {
        // 单例设计模式
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}