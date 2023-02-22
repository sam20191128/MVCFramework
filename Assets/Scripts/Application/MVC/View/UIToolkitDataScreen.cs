using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIToolkitDataScreen : MonoBehaviour
{
    private VisualElement rootVisualElement;

    private void Awake()
    {
        rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rootVisualElement.style.display = rootVisualElement.style.display == DisplayStyle.Flex ? DisplayStyle.None : DisplayStyle.Flex;
        }
    }
}