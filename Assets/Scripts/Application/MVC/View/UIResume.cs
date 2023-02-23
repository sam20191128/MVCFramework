using System.Collections;
using TMPro;
using UnityEngine;

public class UIResume : View
{
    public TMP_Text countDown;
    public int countDownCount = 3;


    public override string Name => Consts.V_Resume;

    public override void HandleEvent(string name, object data)
    {
        //接受事件后，处理事件
    }

    private void Awake()
    {
        countDown = GetComponentInChildren<TMP_Text>();
    }

    //开始计数
    public void StartCount()
    {
        Show();
        StartCoroutine(StartCountCoroutine());
    }

    //开始计数协程
    IEnumerator StartCountCoroutine()
    {
        while (countDownCount > 0)
        {
            countDown.text = countDownCount.ToString();
            countDownCount--;
            yield return new WaitForSeconds(1);
            if (countDownCount <= 0)
            {
                break;
            }
        }

        Hide();
        SendEvent(Consts.E_ContinueGame);
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