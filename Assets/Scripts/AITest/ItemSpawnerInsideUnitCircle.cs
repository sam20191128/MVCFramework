using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawnerInsideUnitCircle : MonoBehaviour
{
    public GameObject[] items; // 物品 Prefab 列表
    public float spawnRadius; // 圆形范围的半径
    private List<GameObject> spawnedItems = new List<GameObject>();

    [Header("CircleGizmo")] public int segments = 32;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float angle = 360f / segments;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 direction = Vector3.forward * spawnRadius;

        for (int i = 0; i < segments; i++)
        {
            Gizmos.DrawLine(transform.position + direction, transform.position + (rotation * direction));
            direction = rotation * direction;
        }
    }

    void Start()
    {
        SpawnItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnItems();
        }
    }

    void SpawnItems()
    {
        for (int i = 0; i < items.Length; i++)
        {
            int numToSpawn = Random.Range(1, 4); // 每个物品实例化的数量
            for (int j = 0; j < numToSpawn; j++)
            {
                Vector2 spawnPos = Random.insideUnitCircle * spawnRadius; // 随机生成圆内位置
                Quaternion spawnRot = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f); // 随机旋转

                // 实例化物品
                GameObject item = Instantiate(items[i], transform.position + new Vector3(spawnPos.x, 0f, spawnPos.y), spawnRot);
                item.transform.localScale *= Random.Range(0.5f, 2f); // 随机大小

                // 检查是否与其他物品重叠，并移动到不重叠的位置
                Collider[] overlapped = Physics.OverlapSphere(item.transform.position, 1f); // 假设物品的半径为 0.5
                foreach (Collider collider in overlapped)
                {
                    if (collider.gameObject != item && spawnedItems.Contains(collider.gameObject))
                    {
                        Vector3 newPos = Vector3.MoveTowards(item.transform.position, collider.transform.position, 0.5f);
                        item.transform.position = new Vector3(newPos.x, item.transform.position.y, newPos.z);
                    }
                }

                spawnedItems.Add(item); // 将实例化的物品添加到列表中
            }
        }
    }
}