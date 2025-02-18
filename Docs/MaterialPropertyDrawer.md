# MaterialPropertyDrawer

```c#
// label argument can be string
public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    // Only the GUI between BeginChangeCheck() and EndChangeCheck() will be checked for changes.
    EditorGUI.BeginChangeCheck();
    EditorGUI.PropertyField(position, property, label);
    if (EditorGUI.EndChangeCheck()) {
        // do something
    }

    // some useful function
    // Material mat = editor.target as Material;
    // MaterialEditor.GetMaterialProperty(new Object[] { mat }, _propertyName);
    // editor.DefaultShaderProeprty(position, prop, label);
}

public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor) {
    return MaterialEditor.GetDefaultPropertyHeight(prop);
}
```

Basically the same as [PropertyDrawer](PropertyDrawer.md).

In shader
```cpp
[Toggle(ColorUsed)] _ColorUsed("Use Color", Float) = 0
[MyToggle(_ColorUsed)] _Color("Color", Color) = (1, 1, 1, 1)
```

The only thing to note is that even if the argument in the constructor is a `string`, you shouldn't add `""`.