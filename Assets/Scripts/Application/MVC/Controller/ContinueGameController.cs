using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameController : Controller
{
    public override void Execute(object data)
    {
        GameModel gm = GetModel<GameModel>();
        gm.IsPause = false;
        gm.IsPlay = true;
    }
}