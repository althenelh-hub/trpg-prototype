using System.Collections.Generic;
using UnityEngine;

public class FastArcSinSort
{
    public List<Vector2Int> sortArc(List<Vector2Int> data, int distance)
    {
        List<Vector2Int> equal = new List<Vector2Int>();
        List<Vector2Int> greater = new List<Vector2Int>();
        List<Vector2Int> lower = new List<Vector2Int>();
        if(data.Count <= 1)
        {
            return data;
        }
        int pivot = data[data.Count/2].y;
        int current = -100000;
        foreach(Vector2Int vec in data)
        {
            current = vec.y;
            if (current > pivot)
            {
                greater.Add(vec);
            }
            else if(current < pivot)
            {
                lower.Add(vec);
            }
            else
            {
                equal.Add(vec);
            }
        }
        greater = sortArc(greater, distance);
        greater.AddRange(equal);
        greater.AddRange(sortArc(lower, distance));
        return greater;
    }
}
