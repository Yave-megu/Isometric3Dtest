using System;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

public class SetTexture {

    [MenuItem("Assets/MySpriteSet" )]
    [Obsolete("Obsolete")]
    static void MySpriteSet() {

        Object[] _textures = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);

        foreach (Texture3D texture in _textures)  {
            string path = AssetDatabase.GetAssetPath(texture); 

            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter; 

            textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;	

            textureImporter.textureType = TextureImporterType.Sprite;

            textureImporter.spriteImportMode = SpriteImportMode.Single;

            textureImporter.generateMipsInLinearSpace = false;

            textureImporter.filterMode = FilterMode.Trilinear;

            AssetDatabase.ImportAsset(path); 

        }
    }
}