using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items; // 可供生成的物品列表
    public Transform spawnPoint; // 生成物品的位置
    public float spawnInterval = 2f; // 生成物品的间隔时间
    public float spawnChance = 0.5f; // 物品生成的概率

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        // 如果时间到了生成间隔时间
        if (timer >= spawnInterval)
        {
            timer = 0f;

            // 随机生成一个数值
            float randomValue = Random.value;

            // 如果生成的数值小于等于生成概率
            if (randomValue <= spawnChance)
            {
                // // 获取一个随机物品
                 //int randomIndex = Random.Range(0, items.Length);
                 //GameObject randomItem = items[randomIndex];

                // 在生成点实例化这个物品
                //Instantiate(randomItem, spawnPoint.position, spawnPoint.rotation);
                GameObject go = ObjectPool.Instance.Spawn("Coin", spawnPoint);
                go.transform.parent = spawnPoint;
                go.transform.position = spawnPoint.position;
            }
        }
    }
}