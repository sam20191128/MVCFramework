using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame1 : View
{
    private Button toGame2Btn;
    private Button toMainMenuBtn;

    GameModel gm;

    private void Awake()
    {
        gm = GetModel<GameModel>();

        toGame2Btn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        toMainMenuBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();

        toGame2Btn.onClick.AddListener(ToGame2);
        toMainMenuBtn.onClick.AddListener(ToMainMenu);
    }

    public override string Name
    {
        get { return Consts.V_UIGame1; }
    }

    public override void HandleEvent(string name, object data)
    {
    }

    void ToGame2()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        GameRoot.Instance.LoadLevel(3);
        Debug.Log("ToGame2");
    }

    void ToMainMenu()
    {
        GameRoot.Instance.sound.PlayEffect("Se_UI_Button");
        GameRoot.Instance.LoadLevel(1);
        Debug.Log("ToMainMenu");
    }
}