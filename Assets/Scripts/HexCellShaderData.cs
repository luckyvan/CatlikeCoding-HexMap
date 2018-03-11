﻿using UnityEngine;

public class HexCellShaderData : MonoBehaviour
{

    Texture2D cellTexture;

    Color32[] cellTextureData;

    public void Initialize(int x, int z)
    {
        if (cellTexture)
        {
            cellTexture.Resize(x, z);
        }
        else
        {
            cellTexture = new Texture2D(x, z, TextureFormat.RGBA32, false, true);
            cellTexture.filterMode = FilterMode.Point;
            cellTexture.wrapMode = TextureWrapMode.Clamp;
        }

        if (cellTextureData == null || cellTextureData.Length != x * z)
        {
            cellTextureData = new Color32[x * z];
        }
        else
        {
            for (int i = 0; i < x*z; i++)
            {
                cellTextureData[i] = new Color32(0, 0, 0, 0);
            }
        }
    }
}