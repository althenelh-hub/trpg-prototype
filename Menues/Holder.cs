using UnityEngine;

public class Holder<T>
{
    T obj;
    public void SetObj(T _obj)
    {
        obj = _obj;
    }
    public T GetObj()
    {
        return obj;
    }
}
