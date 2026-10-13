using UnityEngine;

public class InputManager
{
    public KeyAction[] actions;
    public ActionNames generateAction()
    {
        foreach (KeyAction action in actions) {
            if(Input.GetKeyDown(action.key))
            {
                return action.actionName;
            }
        }
        return ActionNames.NoAction;
    }
}
