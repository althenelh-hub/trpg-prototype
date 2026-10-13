using UnityEngine;
public struct KeyAction 
{
    public KeyAction(KeyCode _key, ActionNames name)
    {
        key = _key;
        actionName = name;
    }
    public KeyCode key;
    public ActionNames actionName;
}
