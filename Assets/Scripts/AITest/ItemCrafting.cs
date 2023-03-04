//以下是使用Unity编写的实现武器装备锻造系统的代码

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrafting : MonoBehaviour
{
    public GameObject[] materials;
    public GameObject[] craftedItems; //合成装备
    public int[] materialQuantities; //材料数量
    public int[] itemQuantities; //item需要材料数量

    public void CraftItem(int selectedItemIndex)
    {
        // 检查是否有足够的材料来制作选定的项目
        bool enoughMaterials = true;
        for (int i = 0; i < materials.Length; i++)
        {
            if (materialQuantities[i] < itemQuantities[selectedItemIndex])
            {
                enoughMaterials = false;
                Debug.Log("enoughMaterials = false;");
                break;
            }
        }

        if (enoughMaterials)
        {
            // 减少材料数量
            for (int i = 0; i < materials.Length; i++)
            {
                materialQuantities[i] -= itemQuantities[selectedItemIndex];
            }

            // 实例化精心制作的项目
            Instantiate(craftedItems[selectedItemIndex]);
        }
    }

    // 显示材料数量和制作按钮
    void OnGUI()
    {
        int x = 10;
        int y = 10;
        for (int i = 0; i < materials.Length; i++)
        {
            GUI.Label(new Rect(x, y, 150, 25), materials[i].name + ": " + materialQuantities[i]);
            y += 25;
        }

        y += 10;
        for (int i = 0; i < craftedItems.Length; i++)
        {
            if (GUI.Button(new Rect(x, y, 150, 25), "Craft " + craftedItems[i].name))
            {
                CraftItem(i);
            }

            y += 25;
        }
    }
}

//此代码实现了一个简单的武器装备锻造系统。
//它由一个包含所有材料和锻造物品的数组和两个数组组成，用于存储每个材料和物品的数量。
//它还包括一个CraftItem（）方法，该方法检查是否有足够的材料制作所选物品，并在有足够材料时实例化制作的物品。
//此外，它还使用onGUI方法显示当前材料数量和可以制作的物品按钮。
//您可以根据需要修改此代码，使其满足您的项目要求。