# PropertyDrawer

## Prerequisites
If you already possess the following skills, reading this project will be easier.
- C# Attribute
- C# Reflection

## Example functions
- **[New]** Automatically call the `Set()` function after the variable is updated

## Changes in the GUI

```c#
public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
    // Only the GUI between BeginChangeCheck() and EndChangeCheck() will be checked for changes.
    EditorGUI.BeginChangeCheck ();
    EditorGUI.PropertyField (position, property, label);
    if (EditorGUI.EndChangeCheck ()) {
        setProperty.IsDirty = true;
    } else if (setProperty.IsDirty) {
        // do something
        setProperty.IsDirty = false;
    }
}
```
It should be noted that after modifying `PropertyField` in the `Inspector`, the actual value has not been set to the current value until the `OnGUI()` was finished. Therefore, variable such as `IsDirty` need to mark whether the Property has been updated and update it in the next `OnGUI()` events.