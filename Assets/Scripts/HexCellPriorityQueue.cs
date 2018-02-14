﻿using System.Collections.Generic;

public class HexCellPriorityQueue
{

    List<HexCell> list = new List<HexCell>();

    int count = 0;

    public int Count
    {
        get
        {
            return count;
        }
    }

    public void Enqueue(HexCell cell)
    {
        int priority = cell.SearchPriority;
        while (priority >= list.Count)
        {
            list.Add(null);
        }
        cell.NextWithSamePriority = list[priority];
        list[priority] = cell;
        count += 1;
    }

    public HexCell Dequeue()
    {
        count -= 1;
        for (int i = 0; i < list.Count; i++)
        {
            HexCell cell = list[i];
            if (cell != null)
            {
                list[i] = cell.NextWithSamePriority;
                return cell;
            }
        }
        return null;
    }

    public void Change(HexCell cell, int oldPriority)
    {
    }

    public void Clear()
    {
        list.Clear();
        count = 0;
    }

    public HexCell NextWithSamePriority { get; set; }
}