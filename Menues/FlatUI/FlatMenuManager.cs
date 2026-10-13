using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlatMenuManager : InputReceiver
{
    public Vector2Int startPosition = new Vector2Int();
    public RectTransform cursorObject;
    public FlatMenu flatMenu;
    public FlatMenuManager(RectTransform cursorObject)
    {
        this.cursorObject = cursorObject;
    }
    public void receiveInput(ActionNames action)
    {
        if(action.Equals(ActionNames.Up)) {
            if (flatMenu.increase()) {
                cursorObject.localPosition += new Vector3(0, flatMenu.step, 0);
            }
        }
        else if (action.Equals(ActionNames.Down))
        {
            Debug.Log(flatMenu.cursorPosition + "before down");
            if (flatMenu.decrease())
            {
                cursorObject.localPosition -= new Vector3(0,flatMenu.step,0);
            }
        }
        else
        {
            flatMenu.receiveInput(action);
        }
    }
    public void receiveMenu(FlatMenu menu)
    {
        menu.startAction();
        cursorObject.localPosition = new Vector3(0,menu.getCursorPosition(),0);
        flatMenu = menu;
    }
    public void startAction(){}
    public override string ToString()
    {
        return "FlatMenu";
    }
}
