using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using System.Diagnostics;
using System;
public class PathFinding : MonoBehaviour {
   
    Grid grid;
    PathRequestManager pathRequestManager;
	void Awake () {
        grid = GetComponent<Grid>();
        pathRequestManager = GetComponent<PathRequestManager>();

    }

    public void StartFindPath(Vector3 StartPos, Vector3 EndPos) {
        StopCoroutine("FindPath");
        StartCoroutine(FindPath(StartPos, EndPos));
    }

    IEnumerator FindPath(Vector3 startPos ,Vector3 targetPos)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        Vector3[] wayPoints = new Vector3[0];
        bool pathSuccess = false;
        
        Node startNode = grid.NodefromWorldPosition(startPos);
        Node targetNode = grid.NodefromWorldPosition(targetPos);

        if (startNode.walkable && targetNode.walkable)
        {
            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                { // 結束條件
                    pathSuccess = true;
                    sw.Stop();
                    //print("Cost: " + sw.ElapsedMilliseconds + "ms");
                    break;
                }

                foreach (Node neighbor in grid.getNeighbours(currentNode))
                {
                    if (!neighbor.walkable || closedSet.Contains(neighbor))
                        continue;

                    int newMovementCost_toNeighbor = currentNode.gCost + getDistance(currentNode, neighbor) + neighbor.movementPenalty;
                    if (newMovementCost_toNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newMovementCost_toNeighbor;
                        neighbor.hCost = getDistance(neighbor, targetNode);
                        neighbor.pareent = currentNode;

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                        else
                            openSet.UpdateItem(neighbor);
                    }
                }
            }
        }
        yield return null;
        if (pathSuccess)
        {
            wayPoints = RetracePath(startNode, targetNode);
        }
        pathRequestManager.FinshedProcessingPath(wayPoints, pathSuccess);
    }

    Vector3[] RetracePath(Node startNode, Node endNode) {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode) {
            path.Add(currentNode);
            currentNode = currentNode.pareent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        //***array Reverse***
        Array.Reverse(waypoints);
        return waypoints;
        
    }

    Vector3[] SimplifyPath(List<Node> nodes)// by direction
    {
        List<Vector3> waypointsList = new List<Vector3>();
        Vector2 OldDirection = Vector2.zero;

        for (int i = 1; i < nodes.Count; i++) {
            Vector2 NewDirection = new Vector2(nodes[i - 1].gridX - nodes[i].gridX, nodes[i - 1].gridY - nodes[i].gridY);
            if (OldDirection != NewDirection)
                waypointsList.Add(nodes[i].worldPosition);
            OldDirection = NewDirection;
        }
        //convert to array 
        return waypointsList.ToArray();
    }

    int getDistance(Node nodeA, Node nodeB) {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        if (distX > distY)
            return 14 * distY + 10 * (distX - distY);
        return 14 * distX + 10 * (distY - distX);
    }
}
