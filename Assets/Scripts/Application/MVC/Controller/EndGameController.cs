public class EndGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();
        gm.IsPlay = false;

        UIDead dead = GetView<UIDead>();
        dead.Show();
    }
}