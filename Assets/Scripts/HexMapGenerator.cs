﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapGenerator : MonoBehaviour {

    public HexGrid grid;

    [Range(0f, 0.5f)]
    public float jitterProbability = 0.25f;

    [Range(20, 200)]
    public int chunkSizeMin = 30;

    [Range(20, 200)]
    public int chunkSizeMax = 100;

    int cellCount;

    HexCellPriorityQueue searchFrontier;

    int searchFrontierPhase;

    public void GenerateMap(int x, int z)
    {
        cellCount = x * z;
        grid.CreateMap(x, z);
        if (searchFrontier == null)
        {
            searchFrontier = new HexCellPriorityQueue();
        }

        for (int i = 0; i < 5; i++)
        {
            RaiseTerrain(Random.Range(chunkSizeMin, chunkSizeMax + 1));
        }

        for (int i = 0; i < cellCount; i++)
        {
            grid.GetCell(i).SearchPhase = 0;
        }
    }

    void RaiseTerrain(int chunkSize)
    {
        searchFrontierPhase += 1;
        HexCell firstCell = GetRandomCell();
        firstCell.SearchPhase = searchFrontierPhase;
        firstCell.Distance = 0;
        firstCell.SearchHeuristic = 0;
        searchFrontier.Enqueue(firstCell);
        HexCoordinates center = firstCell.coordinates;

        int size = 0;
        while (size < chunkSize && searchFrontier.Count > 0)
        {
            HexCell current = searchFrontier.Dequeue();
            current.TerrainTypeIndex = 1;
            size += 1;

            for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++)
            {
                HexCell neighbor = current.GetNeighbor(d);
                if (neighbor && neighbor.SearchPhase < searchFrontierPhase)
                {
                    neighbor.SearchPhase = searchFrontierPhase;
                    neighbor.Distance = neighbor.coordinates.DistanceTo(center);
                    neighbor.SearchHeuristic = Random.value < jitterProbability ? 1 : 0; ;
                    searchFrontier.Enqueue(neighbor);
                }
            }
        }
        searchFrontier.Clear();
    }

    HexCell GetRandomCell()
    {
        return grid.GetCell(Random.Range(0, cellCount));
    }
}
