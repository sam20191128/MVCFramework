public class UpdateCoinController : Controller
{
    public override void Execute(object data)
    {
        CoinArgs e = data as CoinArgs;

        GameModel gm = GetModel<GameModel>();
        UIBoard board = GetView<UIBoard>();

        gm.Coin += e.coin;
        board.txtCoin.text = gm.Coin.ToString();
    }
}