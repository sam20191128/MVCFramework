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
                RegisterView(GameObject.Find("Canvas").transform.Find("UIMainMenu").GetComponent<UIMainMenu>());
                Sound.Instance.PlayBGMAudio("Bgm_JieMian");
                Debug.Log("EnterScenesController---Consts.MainMenuScene");
                break;

            case Consts.Game1Scene:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIDead").GetComponent<UIDead>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIFinalScore").GetComponent<UIFinalScore>());

                Sound.Instance.PlayBGMAudio("Bgm_ZhanDou");
                gm = GetModel<GameModel>();
                gm.IsPause = false;
                gm.IsPlay = true;
                
                Debug.Log("EnterScenesController---Consts.Game1Scene");

                break;
        }
    }
}