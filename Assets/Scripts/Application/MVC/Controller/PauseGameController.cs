public class PauseGameController : Controller
{
    public override void Execute(object data)
    {
        PauseArgs e = data as PauseArgs;
        GameModel gm = GetModel<GameModel>();
        gm.IsPause = true;
        UIPause pause = GetView<UIPause>();
        pause.Show();
    }
}