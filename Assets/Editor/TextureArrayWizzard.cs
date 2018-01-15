using UnityEditor;
using UnityEngine;

public class TextureArrayWizard : ScriptableWizard
{
    public Texture2D[] textures;

    [MenuItem("Assets/Create/Texture Array")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<TextureArrayWizard>(
            "Create Texture Array", "Create"
        );
    }

    void OnWizardCreate()
    {
        if (textures.Length == 0)
        {
            return;
        }

        string path = EditorUtility.SaveFilePanelInProject(
            "Save Texture Array", "Texture Array", "asset", "Save Texture Array"
        );
        if (path.Length == 0)
        {
            return;
        }
    }
}