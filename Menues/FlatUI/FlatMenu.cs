using UnityEngine;

public abstract class FlatMenu : InputReceiver
{
    public int cursorPosition = 0;
    public float step;
    public int upperLimit;
    public FlatMenu(float step, int upperLimit)
    {
        this.step = step;
        this.upperLimit = upperLimit - 1;
    }

    public bool increase()
    {
        if (cursorPosition > 0)
        {
            cursorPosition -= 1;
            return true;
        }
        else return false;
    }
    public bool decrease() {
        if (cursorPosition < upperLimit)
        {
            cursorPosition += 1;
            return true;
        }
        else return false;
    }
    public float getCursorPosition()
    {
        return ((upperLimit)/ 2 - cursorPosition) * step + step/2*((upperLimit)%2);
    }
    public abstract void startAction();
    public abstract void receiveInput(ActionNames name);
}
