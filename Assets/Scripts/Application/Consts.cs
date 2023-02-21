public static class Consts
{
    // Event
    public const string E_StartUp = "E_StartUp";
    public const string E_EnterScenes = "E_EnterScenes";
    public const string E_ExitScenes = "E_ExitScenes";

    public const string E_PauseGame = "E_PauseGame"; //暂停游戏
    public const string E_ResumeGame = "E_ResumeGame"; //恢复游戏
    public const string E_ContinueGame = "E_ContinueGame"; //继续游戏/Resume播放完成后继续游戏
    public const string E_EndGame = "E_EndGame"; //结束游戏

    /// <summary>
    /// UI相关
    /// </summary>

    // 继续游戏

    // Model
    public const string M_GameModel = "M_GameModel";

    // View
    public const string V_MainMenu = "V_MainMenu";
    public const string V_UIGame1 = "V_UIGame1";
    public const string V_UIGame2 = "V_UIGame2";


    //场景名字
    public const string MainMenuScene = "01-MainMenu";
    public const string Game1Scene = "02-Game1";
    public const string Game2Scene = "03-Game2";

    //场景切换淡入淡出过渡
    public const string UssFade = "fade";
}