using UnityEngine;
using UnityEngine.EventSystems;

public class HexGameUI : MonoBehaviour
{

    public HexGrid grid;

    HexCell currentCell;

    public void SetEditMode(bool toggle)
    {
        enabled = !toggle;
        grid.ShowUI(!toggle);
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
}