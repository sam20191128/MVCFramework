using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model
{
    #region 常量

    #endregion

    #region 事件

    #endregion

    #region 字段

    bool m_IsPlay = true;
    bool m_IsPause = false;

    public string lastSceneName;

    #endregion

    #region 属性

    public override string Name
    {
        get { return Consts.M_GameModel; }
    }

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

    #endregion

    #region 方法

    #endregion

    #region Unity回调

    #endregion

    #region 事件回调

    #endregion

    #region 帮助方法

    #endregion
}