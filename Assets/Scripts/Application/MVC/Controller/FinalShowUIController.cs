using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalShowUIController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();

        UIBoard board = GetView<UIBoard>();
        board.Hide();

        UIFinalScore final = GetView<UIFinalScore>();
        final.Show();

        //更新数据


        //更新UI
        final.UpdateUI();

        UIDead dead = GetView<UIDead>();
        dead.Hide();
    }
}