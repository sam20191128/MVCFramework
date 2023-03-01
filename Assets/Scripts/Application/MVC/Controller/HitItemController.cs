public class HitItemController : Controller
{
    public override void Execute(object data)
    {
        ItemArgs e = data as ItemArgs; //碰到的物品信息
        GameModel gm = GetModel<GameModel>();
        UIBoard board = GetView<UIBoard>(); //显示UI
        switch (e.itemType)
        {
            case ItemType.TestItemType:
                //player.XXX();
                //ui.XXX();
                gm.TestMaskCount -= e.hitCount; //-次数
                break;
        }

        board.UpdateUI();
    }
}