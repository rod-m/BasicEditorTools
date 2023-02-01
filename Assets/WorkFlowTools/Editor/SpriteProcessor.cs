using UnityEditor;
using UnityEngine;

namespace WorkFlowTools
{
    public class SpriteProcessor : AssetPostprocessor
    {
        private void OnPostprocessTexture(Texture2D texture)
        {
            var texturePath = assetPath.ToLower();
            var isOk = texturePath.IndexOf("/sprites/") != -1;
            if (isOk)
            {
                var textureImporter = assetImporter as TextureImporter;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spritePixelsPerUnit = 256f;
            }
        }
    }
}