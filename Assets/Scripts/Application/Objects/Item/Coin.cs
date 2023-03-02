using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    int m_Coin = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.player))
        {
            HitPlayer();

            //吃金币
            CoinArgs e = new CoinArgs
            {
                coin = m_Coin
            };
            SendEvent(Consts.E_UpdateCoin, e);
        }
    }

    public void HitPlayer()
    {
        Sound.Instance.PlayEffectAudio("Se_UI_JinBi");

        Destroy(gameObject);
    }
}