using UnityEngine;
using UnityEditor;

public class Example : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled = false;
    int myInt = 0;
    float myFloat = 0.0f;
    bool myBool = false;

    [MenuItem("Window/My Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        Example window = (Example)EditorWindow.GetWindow(typeof(Example));
        window.Show();

        EditorPrefs.GetString("Text Field", "Hello World");
        EditorPrefs.GetInt("Number", 0);
        EditorPrefs.GetFloat("Slider", 0.0f);
        EditorPrefs.GetBool("Toggle", false);
    }

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myInt = EditorGUILayout.IntField("Number", myInt);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        EditorGUILayout.EndToggleGroup();

        if (GUILayout.Button("Save Changes"))
        {
            Debug.Log($"{this} saved successfully!!!");
            EditorPrefs.SetString("Text Field", myString);
            EditorPrefs.SetInt("Number", myInt);
            EditorPrefs.SetFloat("Slider", myFloat);
            EditorPrefs.SetBool("Toggle", myBool);
        }

        // using (new EditorGUI.DisabledScope(!hasUnsavedChanges))
        // {
        //     if (GUILayout.Button("Save"))
        //         SaveChanges();
        // }
    }
}
