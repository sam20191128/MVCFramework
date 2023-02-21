using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame1 : View
{
    private Button toGame2Btn;
    private Button toMainMenuBtn;
    private Button pauseBtn;

    public override string Name => Consts.V_UIGame1;
    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();

        toGame2Btn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        toMainMenuBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        pauseBtn = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        toGame2Btn.onClick.AddListener(ToGame2);
        toMainMenuBtn.onClick.AddListener(ToMainMenu);
        pauseBtn.onClick.AddListener(OnPauseClick);
    }


    public override void HandleEvent(string name, object data)
    {
    }

    private static void ToGame2()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");

        SceneLoader.LoadAddressableScene(Consts.Game2Scene);
        SceneLoader.ExitSceneEvent();
    }

    private static void ToMainMenu()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");

        SceneLoader.LoadAddressableScene(Consts.MainMenuScene);
        SceneLoader.ExitSceneEvent();
    }

    //暂停按钮点击
    public void OnPauseClick()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        PauseArgs e = new PauseArgs
        {
            //暂停游戏时数据
        };

        SendEvent(Consts.E_PauseGame, e);
    }

    // //更新 按钮是否可用
    // public void UpdateUI()
    // {
    //     ShowOrHide(gm.Invincible, btnInvincible);
    //     ShowOrHide(gm.Magnet, btnMagnet);
    //     ShowOrHide(gm.Multiply, btnMultiply);
    // }
    //
    // void ShowOrHide(int i, Button btn)
    // {
    //     if (i > 0)
    //     {
    //         btn.interactable = true; //交互激活
    //         btn.transform.Find("Mask").gameObject.SetActive(false);
    //     }
    //     else
    //     {
    //         btn.interactable = false;
    //         btn.transform.Find("Mask").gameObject.SetActive(true);
    //     }
    // }
}