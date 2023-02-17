using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesIndex)
        {
            case 1:
                break;
            case 2:
                GameRoot.Instance.objectPool.Clear();
                break;
            case 3:
                GameRoot.Instance.objectPool.Clear();
                break;
        }

        GameModel gm = GetModel<GameModel>();
        gm.lastIndex = e.scenesIndex;
    }
}