using UnityEngine;
using UnityEditor;

// User with "[MyToggle]" before a float shader property.
// The "Drawer" suffix of the class name is not written

public class MyToggleDrawer : MaterialPropertyDrawer
{
    private string _propertyName;

    public MyToggleDrawer() { }

    public MyToggleDrawer(string propertyName)
    {
        _propertyName = propertyName;
    }

    public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        // bool value = prop.floatValue != 0.0f;

        // EditorGUI.BeginChangeCheck();
        // EditorGUI.showMixedValue = prop.hasMixedValue;   // display a mixed state value when multiple objects(Material) are selected

        // value = EditorGUI.Toggle(position, label, value);

        // EditorGUI.showMixedValue = false;
        // if (EditorGUI.EndChangeCheck())
        // {
        //     prop.floatValue = value ? 1.0f : 0.0f;
        // }

        Material mat = editor.target as Material;
        if (mat != null)
        {
            MaterialProperty toggleProperty = MaterialEditor.GetMaterialProperty(new Object[] { mat }, _propertyName);
            if (toggleProperty != null && toggleProperty.floatValue == 1)
            {
                editor.DefaultShaderProperty(position, prop, label);
            }
        }
    }

    public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
    {
        Material mat = editor.target as Material;
        if (mat != null)
        {
            MaterialProperty toggleProperty = MaterialEditor.GetMaterialProperty(new Object[] { mat }, _propertyName);
            if (toggleProperty != null && toggleProperty.floatValue == 1)
            {
                return MaterialEditor.GetDefaultPropertyHeight(prop);
            }
        }

        return 0;
    }
}
