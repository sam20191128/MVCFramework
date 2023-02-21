using UnityEngine;
using UnityEngine.UI;

public class UIPause : View
{
    public Text txtDis;
    public Text txtCoin;
    public Text txtScore;
    public SkinnedMeshRenderer skm;
    public MeshRenderer render;

    public override string Name => Consts.V_Pause;
    GameModel gm;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateUI();
    }

    public override void HandleEvent(string name, object data)
    {
    }

    public void OnResumeClick()
    {
        Hide();
        Sound.Instance.PlayEffect("Se_UI_Button");
        SendEvent(Consts.E_ResumeGame);
    }

    public void OnHomeClick()
    {
        Sound.Instance.PlayEffect("Se_UI_Button");
        SceneLoader.LoadAddressableScene(Consts.MainMenuScene);
        SceneLoader.ExitSceneEvent();
    }

    private void Awake()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        gm = GetModel<GameModel>();
        //更新UI数据
    }
}