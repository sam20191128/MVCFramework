//要随机生成3D地图，需要先了解3D地图的基本组成元素。一个基本的3D地图一般由以下几个组成部分组成：
//
//- 地形，包括地面、山脉、河流等；
//- 植被，包括草、树、花等；
//- 建筑物，包括房屋、城堡、堡垒等；
//- 物品，包括宝藏、道具等。
//
//因此，我们可以针对每一个部分编写生成代码。下面是一个基本的随机生成3D地图的代码示例：

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int size = 50; // 地图的大小
    public GameObject[] terrainPrefabs; // 地形的Prefab
    public GameObject[] vegetationPrefabs; // 植被的Prefab
    public GameObject[] buildingPrefabs; // 建筑物的Prefab
    public GameObject[] itemPrefabs; // 物品的Prefab

    void Start()
    {
        GenerateTerrain();
        GenerateVegetation();
        GenerateBuildings();
        GenerateItems();
    }

    // 生成地形
    void GenerateTerrain()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                // 随机选择一个地形Prefab
                int randomIndex = Random.Range(0, terrainPrefabs.Length);
                GameObject terrain = Instantiate(terrainPrefabs[randomIndex], new Vector3(x, 0, z), Quaternion.identity) as GameObject;

                // 对地形进行缩放，确保地形与地面接触
                Vector3 terrainScale = terrain.transform.localScale;
                terrain.transform.localScale = new Vector3(terrainScale.x, Random.Range(0.5f, 2f), terrainScale.z);
            }
        }
    }

    // 生成植被
    void GenerateVegetation()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                // 随机选择一个植被Prefab，并按照一定的概率生成
                int randomIndex = Random.Range(0, vegetationPrefabs.Length);
                float randomValue = Random.value;
                if (randomValue <= 0.1f)
                {
                    GameObject vegetation = Instantiate(vegetationPrefabs[randomIndex], new Vector3(x, 0, z), Quaternion.identity) as GameObject;
                }
            }
        }
    }

    // 生成建筑物
    void GenerateBuildings()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                // 随机选择一个建筑物Prefab，并按照一定的概率生成
                int randomIndex = Random.Range(0, buildingPrefabs.Length);
                float randomValue = Random.value;
                if (randomValue <= 0.05f)
                {
                    GameObject building = Instantiate(buildingPrefabs[randomIndex], new Vector3(x, 0, z), Quaternion.identity) as GameObject;
                }
            }
        }
    }

    // 生成物品
    void GenerateItems()
    {
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                // 随机选择一个物品Prefab，并按照一定的概率生成
                int randomIndex = Random.Range(0, itemPrefabs.Length);
                float randomValue = Random.value;
                if (randomValue <= 0.02f)
                {
                    GameObject item = Instantiate(itemPrefabs[randomIndex], new Vector3(x, 0, z), Quaternion.identity) as GameObject;
                }
            }
        }
    }
}


//在这个代码中，我们将地图分为了四个部分：地形、植被、建筑物和物品。对于每个部分，我们都按照一定的概率随机生成相应的Prefab，并将它们实例化在地图对应的位置上。

//注意，这只是一个基本的示例，你可以根据具体需求进行更加复杂的扩展和修改。也需要特别注意地形和建筑物的实际操作比较复杂，需要使用更加高级的算法和技术。