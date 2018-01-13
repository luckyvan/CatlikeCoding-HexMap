﻿using UnityEngine;

public class SaveLoadMenu : MonoBehaviour
{

    public HexGrid hexGrid;

    bool saveMode;

    public void Open(bool saveMode)
    {
        this.saveMode = saveMode;
        gameObject.SetActive(true);
        HexMapCamera.Locked = true;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        HexMapCamera.Locked = false;
    }
}