using UnityEngine;
using UnityEditor;

public class MyEditorWindow : EditorWindow
{
    [MenuItem("Sam/My Editor Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<MyEditorWindow>("My Editor Window");
    }

    private void OnGUI()
    {
        GUILayout.Label("Testing Methods", EditorStyles.boldLabel);

        if (GUILayout.Button("Method 1"))
        {
            Debug.Log("Method 1 executed.");
        }

        if (GUILayout.Button("Method 2"))
        {
            Debug.Log("Method 2 executed.");
        }

        if (GUILayout.Button("Method 3"))
        {
            Debug.Log("Method 3 executed.");
        }
    }
}
//在这个示例中，我们首先创建了一个 `MyEditorWindow` 类，并添加了一个名为 `ShowWindow()` 的静态方法，
//用于在 Unity 编辑器的菜单栏中添加一个新的菜单项，以便打开这个自定义窗口。

//在 `OnGUI()` 方法中，我们使用 `GUILayout.Label()` 方法添加了一个标签，用于显示一个标题。
//接下来，我们添加了三个按钮，分别用于触发三个测试方法。当用户点击这些按钮时，将会在控制台中输出相应的信息。

//要使用这个自定义窗口，请将此脚本保存到项目中，并在 Unity 编辑器中单击菜单栏中的 "Window"，然后选择 "My Editor Window"。
//然后，您将能够看到一个新的窗口，其中包含三个按钮，可以用来测试您的方法。