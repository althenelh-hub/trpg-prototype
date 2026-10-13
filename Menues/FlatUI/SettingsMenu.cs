using UnityEngine;

public class SettingsMenu
{
    public int volume;
    public bool showAnimations;
    public bool showUnitInfo;
    public int sensivity;
    public void receiveInput(ActionNames name)
    {
        
    }
    public void reduceVolume()
    {
        volume--;
    }
    public void addVolume()
    {
        volume++;
    }
    
    public void checkInputs()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            reduceVolume();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            addVolume();
        }
    }
}
