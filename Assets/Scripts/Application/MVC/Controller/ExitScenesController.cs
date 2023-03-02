using UnityEngine;

public class ExitScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesName)
        {
            case Consts.MainMenuScene:
                Debug.Log("ExitScenesController---Consts.MainMenuScene");
                break;
            case Consts.Game1Scene:
                ObjectPool.Instance.Clear();
                Debug.Log("ExitScenesController---Consts.Game1Scene");
                break;
        }

        GameModel gm = GetModel<GameModel>();
        gm.lastSceneName = e.scenesName;
    }
}