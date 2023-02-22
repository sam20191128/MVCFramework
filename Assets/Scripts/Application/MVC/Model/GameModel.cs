using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量

    #endregion


    #region 字段

    public string lastSceneName;
    int m_Coin;

    #endregion

    #region 属性

    public override string Name => Consts.M_GameModel;

    public bool IsPlay { get; set; } = true;

    public bool IsPause { get; set; } = false;

    public int Invincible { get; set; }

    public int Coin
    {
        get => m_Coin;

        set
        {
            m_Coin = value;
            Debug.Log("现在还剩" + value + "钱");
        }
    }

    #endregion

    #region 方法

    //初始化
    public void Init()
    {
        m_Coin = Consts.InitCoin;
    }

    //扣除金币
    public bool GetMoney(int coin)
    {
        if (coin <= Coin)
        {
            Coin -= coin;
            return true;
        }

        return false;
    }

    #endregion
}