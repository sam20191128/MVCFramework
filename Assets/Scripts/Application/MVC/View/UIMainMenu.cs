using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : View
{
    private Button newGameBtn;
    private Button continueBtn;
    private Button quitBtn;

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

    public override string Name
    {
        get { return Consts.V_MainMenu; }
    }

    public override void HandleEvent(string name, object data)
    {
    }

    void NewGame()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        
        SceneLoader.LoadAddressableScene(Consts.Game1Scene);
    }

    void ContinueGame()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");

        // //转换场景,读取进度
        // if (SaveManager.Instance.SceneName != "")
        // {
        //     SceneController.Instance.TransitionToLoadGame();
        // }
        Debug.Log("继续游戏");
    }

    void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}