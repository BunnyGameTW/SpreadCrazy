using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//Generic Heap
public class Heap<T> where T : IHeapItem<T>{ //限制實作後才能使用

    T[] items;
    int currentItemCount;

    public Heap(int maxHeapSize){
        items = new T[maxHeapSize];
    }

    public void Add(T item) {
        item.Heapindex = currentItemCount;
        items[currentItemCount] = item;
        SortUP(item);
        currentItemCount++;
    }

    public T RemoveFirst()
    {
        T firstItem = items[0];
        currentItemCount--;
        items[0] = items[currentItemCount];
        items[0].Heapindex = 0;
        SortDown(items[0]);
        return firstItem;
    }

    public bool Contains(T item) {
        return Equals(items[item.Heapindex],item);
    }

    public int Count {
        get { return currentItemCount; }
    }

    public void UpdateItem(T item) {
        SortUP(item);
    }

    void SortDown(T item) {
        while (true) {
            int childIndeL = item.Heapindex * 2 + 1;//tree
            int childIndeR = item.Heapindex * 2 + 2;
            int swapIndex = 0;

            if (childIndeL < currentItemCount)
            {
                swapIndex = childIndeL;

                if (childIndeR < currentItemCount)
                {
                    if (items[childIndeL].CompareTo(items[childIndeR]) < 0)
                    {
                        swapIndex = childIndeR;
                    }
                }

                if (item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                    return; 
            }

            else
                return; //到底了
        }
    }

    void SortUP(T item){
        int parentIndex = (item.Heapindex - 1) / 2; //tree
        while (true) {
            T pareentItem = items[parentIndex];
            if (item.CompareTo(pareentItem) > 0)
            {
                Swap(item, pareentItem);
            }
            else
            {
                break;
            }
            parentIndex = (item.Heapindex - 1) / 2;
        }
    }

    void Swap(T itemA, T itemB) {
        items[itemA.Heapindex] = itemB;
        items[itemB.Heapindex] = itemA;

        int tempindex = itemA.Heapindex;
        itemA.Heapindex = itemB.Heapindex;
        itemB.Heapindex = tempindex;
    }
}

//定義特定通用類型的比較方法，實值類型或類別會實作這個方法，以排列或排序其執行個體。

public interface IHeapItem<T> : IComparable<T> {
    int Heapindex {
        get;
        set;
    }
}