using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public override void HitPlayer(Transform pos)
    {
        Sound.Instance.PlayEffect("Se_UI_JinBi");

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.player))
        {
            HitPlayer(other.transform);
            other.SendMessage("HitCoin", SendMessageOptions.RequireReceiver);
        }
    }
}