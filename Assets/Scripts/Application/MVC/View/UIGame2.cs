using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame2 : View
{
    private Button toGame1Btn;
    private Button toMainMenuBtn;

    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();

        toGame1Btn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        toMainMenuBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();

        toGame1Btn.onClick.AddListener(ToGame1);
        toMainMenuBtn.onClick.AddListener(ToMainMenu);
    }

    public override string Name
    {
        get { return Consts.V_UIGame2; }
    }

    public override void HandleEvent(string name, object data)
    {
    }

    void ToGame1()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        GameRoot.Instance.LoadLevel(2);
        Debug.Log("ToGame1");
    }

    void ToMainMenu()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        GameRoot.Instance.LoadLevel(1);
        Debug.Log("ToMainMenu");
    }
}