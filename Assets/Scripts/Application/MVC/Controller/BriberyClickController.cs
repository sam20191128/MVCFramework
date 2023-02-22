public class BriberyClickController : Controller
{
    //贿赂Controller
    public override void Execute(object data)
    {
        CoinArgs e = data as CoinArgs;
        UIDead dead = GetView<UIDead>();
        GameModel gm = GetModel<GameModel>();

        if (gm.GetMoney(e.coin))
        {
            dead.Hide();
            dead.BriberyTime++;
            UIResume resume = GetView<UIResume>();
            resume.StartCount();
        }
    }
}