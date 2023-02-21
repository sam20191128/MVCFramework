using UnityEngine;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        GameModel gm;
        switch (e.scenesName)
        {
            case Consts.MainMenuScene:
                RegisterView(GameObject.Find("UIMainMenu").GetComponent<UIMainMenu>());
                Sound.Instance.PlayBG("Bgm_JieMian");
                Debug.Log("EnterScenesController---Consts.MainMenuScene");
                break;

            case Consts.Game1Scene:
                RegisterView(GameObject.Find("UIGame1").GetComponent<UIGame1>());
                Sound.Instance.PlayBG("Bgm_ZhanDou");
                gm = GetModel<GameModel>();
                gm.IsPause = false;
                gm.IsPlay = true;
                Debug.Log("EnterScenesController---Consts.Game1Scene");

                break;

            case Consts.Game2Scene:
                RegisterView(GameObject.Find("UIGame2").GetComponent<UIGame2>());
                Sound.Instance.PlayBG("Bgm_ZhanDou");
                gm = GetModel<GameModel>();
                gm.IsPause = false;
                gm.IsPlay = true;
                Debug.Log("EnterScenesController---Consts.Game2Scene");

                break;
        }
    }
}