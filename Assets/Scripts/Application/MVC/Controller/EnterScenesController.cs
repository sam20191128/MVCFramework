using UnityEngine;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        switch (e.scenesIndex)
        {
            case 1:
                RegisterView(GameObject.Find("UIMainMenu").GetComponent<UIMainMenu>());
                GameRoot.Instance.sound.PlayBG("Bgm_JieMian");
                break;

            case 2:
                RegisterView(GameObject.Find("UIGame1").GetComponent<UIGame1>());
                GameRoot.Instance.sound.PlayBG("Bgm_JieMian");

                GameModel gm = GetModel<GameModel>();

                break;

            case 3:
                RegisterView(GameObject.Find("UIGame2").GetComponent<UIGame2>());
                GameRoot.Instance.sound.PlayBG("Bgm_JieMian");
                break;
        }
    }
}