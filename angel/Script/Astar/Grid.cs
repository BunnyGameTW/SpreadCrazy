using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public bool DisplayGrid;
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRidus;
    public TerrainType[] walkableRegion;
    LayerMask walkableMask;
    Node[,] grid;
    float nodeDiameter;
    int gridSizeX,gridSizeY;
    public int MaxSize{
        get { return gridSizeX * gridSizeY; }  
    }
    Dictionary<int, int> walkableRegionDictionary = new Dictionary<int, int>();

    private void Awake()
    {
        nodeDiameter = nodeRidus * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);

        foreach (TerrainType region in walkableRegion) {
            walkableMask = walkableMask | region.terrianMask;
            walkableRegionDictionary.Add( (int)Mathf.Log(region.terrianMask.value, 2), region.terrianPenalty);
        }
        CreateGrid();

    }

    void CreateGrid() /////
    {
        grid = new Node[gridSizeX,gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldposition = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRidus) + Vector3.up * (y * nodeDiameter + nodeRidus);
                //bool walkable = !(Physics.CheckSphere(worldposition, nodeRidus,unwalkableMask));
                bool walkable = true;
                Vector2 worldV2 = new Vector2(worldposition.x, worldposition.y); //for 2D
                //Ray2D ray2d = new Ray2D(worldV2, Vector2.zero);//平行Z軸射線
                // Physics2D.Raycast 與 Physics.Raycast不同
                RaycastHit2D hit2D = Physics2D.Raycast(worldV2, Vector2.zero, 100, unwalkableMask);
                if (hit2D.collider != null)
                {
                    walkable = false;
                }
                int penalty = 0;

                //raycast
                
                if (walkable)
                {
                    //Ray ray = new Ray(worldposition + Vector3.up * 50, Vector3.down);
                    //RaycastHit hit;
                    //if (Physics.Raycast(ray, out hit, 100, walkableMask)) {
                    //    walkableRegionDictionary.TryGetValue(hit.collider.gameObject.layer,out penalty);
                    //}
                    
                    RaycastHit2D hit2D2 = Physics2D.Raycast(worldV2, Vector2.zero,100, walkableMask);
                    if (hit2D2.collider != null) {
                        Debug.Log("111");
                        walkableRegionDictionary.TryGetValue(hit2D2.collider.gameObject.layer, out penalty);
                    }
                }
                grid[x, y] = new Node(walkable, worldposition, x, y, penalty);
            }
        }
    }

    public List<Node> getNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();
        
        for (int x = -1; x <= 1; x++) {
            for (int y = -1; y <= 1; y++) //先看相對座標
            {
                if (x == 0 && y == 0)
                    continue;
                int checkX = x + node.gridX;
                int checkY = y + node.gridY;
                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }

    
    private void OnDrawGizmos()//////
    {
        Gizmos.DrawWireCube(transform.position ,new Vector3(gridWorldSize.x, gridWorldSize.y,1));
        if (grid != null && DisplayGrid) { 
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                //print(n.walkable);
                
                //if (n.movementPenalty == walkableRegion[1].terrianPenalty) {
                //    Gizmos.color = Color.blue;
                //}
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
            }
        }
    }

    public Node NodefromWorldPosition(Vector3 worldPosition)//
    {
        float percentX = (worldPosition.x - transform.position.x + (gridWorldSize.x ) / 2) / gridWorldSize.x;
        float percentY = (worldPosition.y - transform.position.y + (gridWorldSize.y ) / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int X = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int Y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        int i = 0;
        // force return node is walkable
        while (!grid[X, Y].walkable)
        {
            i++;
            if (grid[Mathf.Clamp(X + i, 0, gridSizeX - 1), Y].walkable)
                return grid[Mathf.Clamp(X + i, 0, gridSizeX - 1), Y];
            else if (grid[Mathf.Clamp(X - i, 0, gridSizeX - 1), Y].walkable)
                return grid[Mathf.Clamp(X - i, 0, gridSizeX - 1), Y];
            else if (grid[X, Mathf.Clamp(Y + i, 0, gridSizeY - 1)].walkable)
                return grid[X, Mathf.Clamp(Y + i, 0, gridSizeY - 1)];
            else if (grid[X, Mathf.Clamp(Y - i, 0, gridSizeY - 1)].walkable)
                return grid[X, Mathf.Clamp(Y - i, 0, gridSizeY - 1)];
        }
        return grid[X, Y];
    }
}
[System.Serializable]
public class TerrainType {
    public LayerMask terrianMask;
    public int terrianPenalty;
}