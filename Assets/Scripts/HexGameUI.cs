﻿using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour
{

    public HexGrid grid;

    HexCell currentCell;

    HexUnit selectedUnit;

    public void SetEditMode(bool toggle)
    {
        enabled = !toggle;
        grid.ShowUI(!toggle);
        grid.ClearPath();
    }

    bool UpdateCurrentCell()
    {
        var cell =
            grid.GetCell(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (cell != currentCell)
        {
            currentCell = cell;
            return true;
        }

        return false;
    }

    void DoSelection()
    {
        grid.ClearPath();
        UpdateCurrentCell();
        if (currentCell)
        {
            selectedUnit = currentCell.Unit;
        }
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoSelection();
            }
            else if (selectedUnit)
            {
                DoPathfinding();
            }
        }
    }

    void DoPathfinding()
    {
        if (UpdateCurrentCell())
        {
            if (currentCell)
            {
                grid.FindPath(selectedUnit.Location, currentCell, 24);
            }
            else
            {
                grid.ClearPath();
            }
        }
    }
}