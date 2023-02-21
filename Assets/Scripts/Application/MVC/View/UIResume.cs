using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIResume : View
{
    public override string Name => Consts.V_Resume;

    public override void HandleEvent(string name, object data)
    {
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}