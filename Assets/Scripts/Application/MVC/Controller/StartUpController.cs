public class StartUpController : Controller
{
    //执行
    public override void Execute(object data)
    {
        //注册所有 Controller
        RegisterController(Consts.E_EnterScenes, typeof(EnterScenesController));
        RegisterController(Consts.E_ExitScenes, typeof(ExitScenesController));

        RegisterController(Consts.E_PauseGame, typeof(PauseGameController));
        RegisterController(Consts.E_ResumeGame, typeof(ResumeGameController));
        RegisterController(Consts.E_ContinueGame, typeof(ContinueGameController));
        RegisterController(Consts.E_EndGame, typeof(EndGameController));

        RegisterController(Consts.E_FinalShowUI, typeof(FinalShowUIController)); //最终结算
        RegisterController(Consts.E_BriberyClick, typeof(BriberyClickController)); //贿赂

        //注册 Model
        RegisterModel(new GameModel());

        //初始化
        GameModel gm = GetModel<GameModel>();
        gm.Init();
    }
}