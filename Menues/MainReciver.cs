using System.Collections.Generic;
using UnityEngine;
public class MainReceiver
{
    public InputReceiver current;
    public FlatMenuManager menuManager;
    public Dictionary<UINames, InputReceiver> inputReceivers = new Dictionary<UINames, InputReceiver>();
    public Dictionary<UINames, FlatMenu> userInterfaces = new Dictionary<UINames, FlatMenu>();
    public UISystem uiSystem;
    public void startSystem(VolumeCursorData cursorData, CursorMovementControl movementControl, MovingSystem movingSystem,
        UISystem uiSystem, RectTransform rectTransform, BattleSystem battlSystem, Camera camera)
    {
        UniifiedStorage storage = new UniifiedStorage();
        storage.camera = camera;
        inputReceivers.Add(UINames.ChoseUnitAction, new ChoseUnitAction(this, cursorData, movementControl, storage));
        current = inputReceivers[UINames.ChoseUnitAction];
        ConfirmInteractionUI confirmInteraction = new ConfirmInteractionUI(65, 0, storage, this);
        inputReceivers.Add(UINames.ConfirmMovement, new ConfirmAction(cursorData, movingSystem, movementControl, this, storage));
        inputReceivers.Add(UINames.SkillControl, new SkillToInput(new SkillUI(cursorData, this, storage, battlSystem, movementControl),
            new TargetSelectUI(cursorData, movementControl.cursor, storage, battlSystem, movementControl, this), storage, this, new InteractionUI(cursorData, storage,
            confirmInteraction, this)));
        userInterfaces.Add(UINames.ConfirmInteraction, confirmInteraction);
        menuManager = new FlatMenuManager(rectTransform);
        userInterfaces.Add(UINames.ChoseSkillMenu, new ChoseSkillMenu(65, 4, this, storage));
        this.uiSystem = uiSystem;
    }
    public void receiveAction(ActionNames name)
    {
        if (!name.Equals(ActionNames.NoAction))
        {
            Debug.Log(name);
            current.receiveInput(name);
        }
    }
    public void changeInputReceiver(UINames name)
    {
        if (inputReceivers.ContainsKey(name))
        {
            current = inputReceivers[name];
            current.startAction();
        }
    }
    public void showFlatMenu(UINames name)
    {
        current = menuManager;
        menuManager.receiveMenu(userInterfaces[name]);
        showUI(name);
    }
    public void showUI(UINames name)
    {
        uiSystem.showMenu(name);
    }
    public void hideUI(UINames name)
    {
        uiSystem.hideMenu(name);
    }
    public void fillButtons(UINames name, string[] texts, int buttonHeight, int gap, int width)
    {
        uiSystem.fillButtons(name, texts, buttonHeight, gap, width);
        showUI(name);
    }
    
    
    
    

}
