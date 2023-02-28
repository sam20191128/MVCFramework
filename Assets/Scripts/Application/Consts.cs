public static class Consts
{
    #region Event

    public const string E_StartUp = "E_StartUp";
    public const string E_EnterScenes = "E_EnterScenes";
    public const string E_ExitScenes = "E_ExitScenes";

    public const string E_PauseGame = "E_PauseGame"; //暂停游戏
    public const string E_ResumeGame = "E_ResumeGame"; //恢复游戏
    public const string E_ContinueGame = "E_ContinueGame"; //继续游戏/Resume播放完成后继续游戏
    public const string E_EndGame = "E_EndGame"; //结束游戏

    #region UI

    public const string E_FinalShowUI = "E_FinalShowUI"; //结算事件

    public const string E_BriberyClick = "E_BriberyClick"; //贿赂

    public const string E_HitItem = "E_HitItem";

    public const string E_UpdateCoin = "E_UpdateCoin"; //CoinArgs

    #endregion

    #endregion

    #region Model

    public const string M_GameModel = "M_GameModel";

    #endregion


    #region View

    public const string V_PlayerManager = "V_PlayerManager";

    public const string V_MainMenu = "V_MainMenu";
    public const string V_UIBoard = "V_UIBoard";

    public const string V_Pause = "V_Pause";
    public const string V_Resume = "V_Resume";
    public const string V_Dead = "V_Dead";

    public const string V_FinalScore = "V_FinalScore";

    #endregion

    #region 场景

    //场景名字
    public const string MainMenuScene = "01-MainMenu";
    public const string Game1Scene = "02-Game1";
    public const string Game2Scene = "03-Game2";

    //场景切换淡入淡出过渡
    public const string UssFade = "fade";

    #endregion

    #region 常量

    public const int InitCoin = 0; //初始金币

    #endregion
}

//吃到奖励物品类型
public enum ItemType
{
    TestItemType
}