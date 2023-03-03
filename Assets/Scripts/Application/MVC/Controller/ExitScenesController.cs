using UnityEngine;

public class ExitScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesIndex)
        {
            case 0:
                break;
            case 1:
                ObjectPool.Instance.Clear();
                break;
        }

        GameModel gm = GetModel<GameModel>();
        gm.lastIndex = e.scenesIndex;
    }
}