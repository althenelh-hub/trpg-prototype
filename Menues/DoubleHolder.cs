using UnityEngine;

public class DoubleHolder <A,B>
{
    A first;
    B second;
    public void SetData(A AData, B BData)
    {
        first = AData;
        second = BData;
    }
    public A GetFirst() { return first; }
    public B GetSecond() { return second; }
}
