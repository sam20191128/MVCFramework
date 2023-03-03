using UnityEngine.UI;

public class UIPause : View
{
    private Button resumeBtn;
    private Button toMainMenuBtn;

    public override string Name => Consts.V_Pause;
    GameModel gm;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    private void Awake()
    {
        gm = GetModel<GameModel>();

        resumeBtn = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        toMainMenuBtn = transform.GetChild(0).GetChild(1).GetComponent<Button>();

        resumeBtn.onClick.AddListener(OnResumeClick);
        toMainMenuBtn.onClick.AddListener(OnToMainMenuClick);

        UpdateUI();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    void UpdateUI()
    {
        gm = GetModel<GameModel>();
        //更新gm数据
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


    public void OnResumeClick()
    {
        Hide();
        Sound.Instance.PlayEffect("Se_UI_Button");
        SendEvent(Consts.E_ResumeGame);
    }

    private static void OnToMainMenuClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        SceneLoader.Instance.LoadLevel(0);
    }
}