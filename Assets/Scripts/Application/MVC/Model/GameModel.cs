using UnityEngine;

public class GameModel : Model
{
    #region 常量

    #endregion


    #region 字段

    private bool m_IsPlay = true;
    private bool m_IsPause = false;

    public int lastIndex = 0;

    private int m_Level;
    private int m_Coin;
    private int m_Exp;

    private int m_TestMaskCount;

    #endregion

    #region 属性

    public override string Name => Consts.M_GameModel;

    public bool IsPlay
    {
        get { return m_IsPlay; }

        set { m_IsPlay = value; }
    }

    public bool IsPause
    {
        get { return m_IsPause; }

        set { m_IsPause = value; }
    }

    public int TestMaskCount
    {
        get { return m_TestMaskCount; }

        set { m_TestMaskCount = value; }
    }

    public int Exp
    {
        get { return m_Exp; }

        set
        {
            while (value > 500 + Level * 100) //该升级了
            {
                value -= 500 + Level * 100;
                Level++;
            }

            m_Exp = value;
        }
    }

    public int Level
    {
        get { return m_Level; }

        set { m_Level = value; }
    }

    public int Coin
    {
        get => m_Coin;

        set
        {
            m_Coin = value;
            Debug.Log("现在还剩" + value + "金币");
        }
    }

    #endregion

    #region 方法

    //初始化
    public void Init()
    {
        m_Exp = 0;
        m_Level = 1;
        m_Coin = Consts.InitCoin;
        m_TestMaskCount = 2;
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