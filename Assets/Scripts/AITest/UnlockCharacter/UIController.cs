using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Character selectedCharacter;
    public Text diamondCountText;

    void Update()
    {
        // 更新钻石计数显示
        diamondCountText.text = "Diamonds: " + GameManager.instance.diamondCount.ToString();
    }

    // 当玩家点击解锁按钮时调用
    public void UnlockButton()
    {
        if (selectedCharacter != null && selectedCharacter.status == CharacterStatus.Locked)
        {
            selectedCharacter.UnlockCharacter();
        }
    }
}

//通过这种方式，可以在游戏中创建一个解锁角色的系统，玩家可以通过收集钻石或其他奖励进行解锁。