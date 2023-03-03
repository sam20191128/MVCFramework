using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : View
{
    private static Button newGameBtn;
    private static Button continueBtn;
    private static Button quitBtn;

    public override string Name => Consts.V_MainMenu;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();

        newGameBtn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        continueBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        quitBtn = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        newGameBtn.onClick.AddListener(NewGame);
        continueBtn.onClick.AddListener(ContinueGame);
        quitBtn.onClick.AddListener(QuitGame);
    }


    private static void NewGame()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        newGameBtn.interactable = false;
        SceneLoader.Instance.LoadLevel(1);
    }

    private static void ContinueGame()
    {
        continueBtn.interactable = false;

        Sound.Instance.PlayEffect("Se_UI_Button");
        
        Debug.Log("继续游戏");
    }

    private static void QuitGame()
    {
        Application.Quit();
        quitBtn.interactable = false;
        Debug.Log("退出游戏");
    }
}