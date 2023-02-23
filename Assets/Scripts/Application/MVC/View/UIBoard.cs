using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoard : View
{
    private Button pauseBtn;
    private Button testMaskBtn;

    public override string Name => Consts.V_UIBoard;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    GameModel gm;

    private void Awake()
    {
        pauseBtn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        testMaskBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        pauseBtn.onClick.AddListener(OnPauseClick);
        testMaskBtn.onClick.AddListener(TestMaskClick);

        gm = GetModel<GameModel>();
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    //暂停按钮点击
    public void OnPauseClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        PauseArgs e = new PauseArgs
        {
            //暂停游戏时数据
        };

        SendEvent(Consts.E_PauseGame, e);
    }

    //测试用
    public void TestMaskClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        // gm.TestMaskCount -= 1;
        // Debug.Log(gm.TestMaskCount);
        ItemArgs e = new ItemArgs
        {
            hitCount = 1,
            itemType = ItemType.TestItemType
        };
        SendEvent(Consts.E_HitItem, e);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    //更新 按钮是否可用
    public void UpdateUI()
    {
        ShowOrHide(gm.TestMaskCount, testMaskBtn);
    }

    //交互激活或隐藏（道具数量，button）
    private void ShowOrHide(int i, Button btn)
    {
        if (i > 0)
        {
            btn.interactable = true; //交互激活
            btn.transform.Find("Mask").gameObject.SetActive(false);
        }
        else
        {
            btn.interactable = false;
            btn.transform.Find("Mask").gameObject.SetActive(true);
        }
    }
}