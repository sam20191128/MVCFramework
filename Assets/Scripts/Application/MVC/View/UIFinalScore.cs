using UnityEngine.UI;

public class UIFinalScore : View
{
    private Button replayBtn;
    private Button toMainMenuBtn;

    public override string Name => Consts.V_FinalScore;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    private void Awake()
    {
        replayBtn = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Button>();
        toMainMenuBtn = transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Button>();

        replayBtn.onClick.AddListener(OnReplayClick);
        toMainMenuBtn.onClick.AddListener(OnMainClick);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    //更新UI
    public void UpdateUI()
    {
    }

    public void OnReplayClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        SceneLoader.LoadAddressableScene(Consts.Game1Scene);
        SceneLoader.ExitSceneEvent();
    }

    public void OnMainClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        SceneLoader.LoadAddressableScene(Consts.MainMenuScene);
        SceneLoader.ExitSceneEvent();
    }
}