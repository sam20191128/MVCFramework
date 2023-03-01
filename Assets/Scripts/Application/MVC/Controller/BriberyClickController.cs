public class BriberyClickController : Controller
{
    //贿赂Controller
    public override void Execute(object data)
    {
        CoinArgs e = data as CoinArgs;
        GameModel gm = GetModel<GameModel>();
        UIDead dead = GetView<UIDead>();
        UIBoard board = GetView<UIBoard>();
        UIResume resume = GetView<UIResume>();

        if (gm.GetMoney(e.coin))
        {
            dead.Hide();
            dead.BriberyTime++;
            board.txtCoin.text = gm.Coin.ToString();

            resume.StartCount();
        }
    }
}