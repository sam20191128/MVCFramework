using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDead : View
{
    [Header("贿赂需要的钱")] public TMP_Text txtBribery; //贿赂需要的钱

    private Button briberyBtn;
    private Button cancelBtn;

    public override string Name => Consts.V_Dead;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    private void Awake()
    {
        BriberyTime = 1;

        briberyBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        cancelBtn = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        briberyBtn.onClick.AddListener(BriberyClick);
        cancelBtn.onClick.AddListener(CancelClick);
    }

    public int BriberyTime { get; set; } = 1; //贿赂次数

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        txtBribery.text = (2 * BriberyTime).ToString(); //贿赂需要的钱
        gameObject.SetActive(true);
    }

    //贿赂需要金币
    public void BriberyClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        CoinArgs e = new CoinArgs
        {
            coin = BriberyTime * 2
        };
        SendEvent(Consts.E_BriberyClick, e);
    }

    //拒绝贿赂
    public void CancelClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        SendEvent(Consts.E_FinalShowUI);
    }
}