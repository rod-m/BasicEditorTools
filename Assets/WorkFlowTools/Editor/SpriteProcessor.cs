using System;
using UnityEditor;
using UnityEngine;

namespace WorkFlowTools
{
    public class SpriteProcessor : AssetPostprocessor
    {
        private void OnPostprocessTexture(Texture2D texture)
        {
            string texturePath = assetPath.ToLower();
            bool isOk = texturePath.IndexOf("/sprites/") != -1;
            if (isOk)
            {
                TextureImporter textureImporter = assetImporter as TextureImporter;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spritePixelsPerUnit = 256f;

            }
        }
    }
}