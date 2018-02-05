using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node :IHeapItem<Node>{

    private int _Heapindex;
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public Node pareent;
    public int movementPenalty;
    public Node(bool b , Vector3 v3 ,int _gridX , int _gridY ,int _penalty)
    {
        walkable = b;
        worldPosition = v3;
        gridX = _gridX;
        gridY = _gridY;
        movementPenalty = _penalty;
    }


    public int gCost; //distance from strating node
    public int hCost; //distance from end node
    public int fCost
    {
        get {
            return gCost + hCost;
        }
    }
    
    public int Heapindex
    {
        get {
            return _Heapindex;
        }
        set {
            _Heapindex = value;
        }
    }

    public int CompareTo(Node NodeToCompare) {
        int Compare = fCost.CompareTo(NodeToCompare.fCost);
        if (Compare == 0)
            Compare = hCost.CompareTo(NodeToCompare.hCost);
        return -Compare; // retuen the lawer cost
    }
}
