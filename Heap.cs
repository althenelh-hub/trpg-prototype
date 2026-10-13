using System;
using UnityEngine;

public class Heap<T> where T : IHeapItem<T>
{
    T[] items;
    int currentItmeCount;
    public Heap(int maxHeapSize)
    {
        items = new T[maxHeapSize];
    }
    public void Add(T item)
    {
        item.HeapIndex = currentItmeCount;
        items[currentItmeCount] = item;
        sortUp(item);
        currentItmeCount++;
    }
    public T getItem(int index)
    {
        return items[index];
    }
    public T removeFirst()
    {
        T firstItem = items[0];
        currentItmeCount--;
        items[0] = items[currentItmeCount];
        items[0].HeapIndex = 0;
        SortDown(items[0]);
        return firstItem;
    }
    public void UpdateItem(T item)
    {
        sortUp(item);
    }
    public int Count
    {
        get { return currentItmeCount; }
    }
    public bool Contains(T item)
    {
        return Equals(items[item.HeapIndex], item);
    }
    void SortDown(T item)
    {
        int i = 0;
        while(true)
        {
            i++;
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;
            if(childIndexLeft < currentItmeCount)
            {
                swapIndex = childIndexLeft;
                if(childIndexRight < currentItmeCount)
                {
                    if(childIndexLeft.CompareTo(childIndexRight) < 0)
                    {
                        swapIndex = childIndexRight;
                    }
                }

                if (item.CompareTo(items[swapIndex]) < 0)
                {
                    Swap(item, items[swapIndex]);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
    }
    void sortUp(T item)
    {
        int i = 0;
        int parentIndex = (item.HeapIndex - 1) / 2;
        while(true)
        {
            i++;
            T parent = items[parentIndex];
            if(item.CompareTo(parent) > 0)
            {
                Swap(parent, item);
            }
            else
            {
                break;
            }
            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }
    void Swap(T itemA, T itemB)
    {
        items[itemA.HeapIndex] = itemB;
        items[itemB.HeapIndex] = itemA;
        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }

}
public interface IHeapItem<T> : IComparable<T>
{
    int HeapIndex
    {
        get;
        set;
    }
}
