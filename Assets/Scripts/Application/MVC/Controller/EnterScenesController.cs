using UnityEngine;

public class EnterScenesController : Controller
{
    public override void Execute(object data)
    {
        ScenesArgs e = data as ScenesArgs;
        GameModel gm;
        
        switch (e.scenesIndex)
        {
            case 0:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIMainMenu").GetComponent<UIMainMenu>());
                Sound.Instance.PlayBGM("Bgm_JieMian");
                break;

            case 1:
                RegisterView(GameObject.Find("Canvas").transform.Find("UIBoard").GetComponent<UIBoard>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIPause").GetComponent<UIPause>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIResume").GetComponent<UIResume>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIDead").GetComponent<UIDead>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIFinalScore").GetComponent<UIFinalScore>());
                Sound.Instance.PlayBGM("Bgm_ZhanDou");
                gm = GetModel<GameModel>();
                gm.IsPause = false;
                gm.IsPlay = true;
                break;
        }
    }
}