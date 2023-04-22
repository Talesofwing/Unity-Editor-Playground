# ScriptableWizard

## What is Wizard?

In computer science, `Wizard` refers to a type of user interface element that provides step-by-step guidance to the user.

`ScriptableWizard` is the Unity version of the `Wizard`.

## Unity Wizard (ScriptableWizard)

```csharp
using UnityEditor;

public class MyWizard : ScriptableWizard { }
```

Inherit from `ScriptableWizard` like the code above👆. It consists of four parts,

![ScriptableWizard](/Images/001.png)

and five functions.

```csharp
    [MenuItem ("zer0/ScriptableWizard/MyWizard")]
    private static void CreateWizard () {
        DisplayWizard<MyWizard> ("Title", "Create Button", "Other Button");
    }

    // It will be called when the wizard open.
    // Note: Wizard only have the Awake() function and don't have Start() function or any others.
    private void Awake () {}

    // On create button click.
    private void OnWizardCreate () {}

    // On other button click.
    private void OnWizardOtherButton () {}

    // It will be called once when the wizard open.
    // It will be called when propeties are changed.
    private void OnWizardUpdate () {}
```