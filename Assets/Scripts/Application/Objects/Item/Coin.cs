using System.Collections;
using UnityEngine;

public class Coin : Item
{
    public Transform effectPrentTransform;

    public int m_Coin = 1;

    public float moveSpeed = 20;

    private void Awake()
    {
        effectPrentTransform = GameObject.Find("EffectParent").transform;
    }

    public override void OnSpawn()
    {
        base.OnSpawn();
    }

    public override void OnUnSpawn()
    {
        base.OnUnSpawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag.player))
        {
            HitPlayer(other.transform);

            //吃金币，更新金币
            CoinArgs e = new CoinArgs
            {
                coin = m_Coin
            };
            GameRoot.Instance.SendEvent(Consts.E_UpdateCoin, e);
        }
        else if (other.CompareTag(Tag.magnet))
        {
            StartCoroutine(HitMagnet(other.transform)); //飞向主角
        }
    }

    public void HitPlayer(Transform transform)
    {
        //1.特效
        //GameObject effect = ObjectPool.Instance.Spawn("FX_JinBi", effectPrentTransform);
        //effect.transform.position = transform.position;

        //2.声音
        Sound.Instance.PlayEffect("Se_UI_JinBi");

        //3.回收
        ObjectPool.Instance.UnSpawn(gameObject);
    }

    //飞向主角
    IEnumerator HitMagnet(Transform otherTransform)
    {
        bool isLoop = true;

        while (isLoop)
        {
            transform.position = Vector3.Lerp(transform.position, otherTransform.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, otherTransform.position) < 0.5f)
            {
                isLoop = false;
                HitPlayer(otherTransform);

                //吃金币，更新金币
                CoinArgs e = new CoinArgs
                {
                    coin = m_Coin
                };
                GameRoot.Instance.SendEvent(Consts.E_UpdateCoin, e);
            }

            yield return 0;
        }
    }
}