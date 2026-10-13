using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public int heapIndex;
    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }
    public Vector2Int position;
    public Node previous;
    public int remainingMovement;
    public Node(Vector2Int position, Node previous, int remainingMovement)
    {
        this.position = position;
        this.previous = previous;
        this.remainingMovement = remainingMovement;
    }
    public int CompareTo(Node other)
    {
        return other.remainingMovement.CompareTo(remainingMovement);
    }
}
public class Dijsktra
{
    public Dictionary<TerrainName, int> penalies = new Dictionary<TerrainName, int>();
    Dictionary<Vector2Int, Node> explored = new Dictionary<Vector2Int, Node>();
    public Dijsktra()
    {
        penalies.Add(TerrainName.Plain, 1);
        penalies.Add(TerrainName.Forest, 2);
    }
    public bool Contains(Vector2Int pos)
    {
        return explored.ContainsKey(pos);
    }
    public void createZone(Extractor extractor, int range)
    {
        explored.Clear();
        Heap<Node> exploring = new Heap<Node>(Mathf.RoundToInt(Mathf.Pow(range*2+1,2)/2 + 1));
        Vector2Int start = extractor.marker;
        Node startNode = new Node(start, null, range);
        exploring.Add(startNode);
        int i = 0;
        explored.Add(start, startNode);
        while (exploring.Count > 0)
        {
            Node current = exploring.removeFirst();
            if(current.remainingMovement <= 0)
            {
                continue;
            }
            List<Vector2Int> temp = findNeighbours(extractor, current);
            foreach (Vector2Int pos in temp) {
                Terrain terrain = extractor.getTerrain(pos);
                if (explored.ContainsKey(pos)) {
                    Node node = explored[pos];
                    if(node.remainingMovement < current.remainingMovement-1)
                    {
                        node.remainingMovement = current.remainingMovement-penalies[terrain.terrainName];
                        node.previous = current;
                    }
                    
                }
                else
                {
                    Node node = new Node(pos, current, current.remainingMovement - penalies[terrain.terrainName]);
                    exploring.Add(node);
                    explored.Add(pos,node);
                }

            }
        }
    }
    public Vector2Int[] getPositions()
    {
        Vector2Int[] result = new Vector2Int[explored.Count];
        int i = 0;
        foreach(Vector2Int vec in explored.Keys)
        {
            result[i] = vec;
            i++;
        }
        return result;
    }
    List<Vector2Int> findNeighbours(Extractor extractor, Node node)
    {
        List<Vector2Int> result = new List<Vector2Int>();
        if(node.position.x + 1 < extractor.level.map.GetLength(0))
        {
            Vector2Int position = node.position + new Vector2Int(1, 0);
            if(extractor.isPassable(position))
            {
                result.Add(position);
            }
            
        }
        if(node.position.y + 1 < extractor.level.map.GetLength(1))
        {
            Vector2Int position = node.position + new Vector2Int(0, 1);
            if (extractor.isPassable(position))
            {
                result.Add(position);
            }
        }
        if (node.position.y - 1 >= 0)
        {
            Vector2Int position = node.position + new Vector2Int(0, -1);
            if (extractor.isPassable(position))
            {
                result.Add(position);
            }
        }
        if (node.position.x - 1 >= 0)
        {
            Vector2Int position = node.position + new Vector2Int(-1, 0);
            if (extractor.isPassable(position))
            {
                result.Add(position);
            }
        }
        return result;

    }
}
