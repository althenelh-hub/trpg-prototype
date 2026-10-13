using System.Collections.Generic;
using UnityEngine;

public class SkillToInput : InputReceiver
{
    public UniifiedStorage storage;
    InputReceiver receiver;
    SkillUI skillUI;
    InteractionUI interactionUI;
    TargetSelectUI targetSelectUI;
    MainReceiver mainReceiver;
    public SkillToInput(SkillUI skillUI, TargetSelectUI targetSelectUI, UniifiedStorage uniifiedStorage, 
        MainReceiver mainReceiver, InteractionUI interaction)
    {
        this.skillUI = skillUI;
        this.targetSelectUI = targetSelectUI;
        this.mainReceiver = mainReceiver;
        storage = uniifiedStorage;
        interactionUI = interaction;
    }
    public void startAction()
    {
        if (storage.getSkill().shapeName == ShapeName.Interaction)
        {
            receiver = interactionUI;
        }
        else if (storage.getSkill().shapeName != ShapeName.TargetSelect)
        {
            receiver = skillUI;
        }
        else
        {
            receiver = targetSelectUI;
        }
        receiver.startAction();
    }
    public void receiveInput(ActionNames name)
    {
        if(name.Equals(ActionNames.Escape))
        {
            mainReceiver.showFlatMenu(UINames.ChoseSkillMenu);
            float posY  = storage.camera.transform.position.y;
            mainReceiver.current = mainReceiver.menuManager;
            storage.camera.transform.position = new Vector3(storage.getUnit().transform.position.x, posY, 
                storage.getUnit().transform.transform.position.z);
        }
        receiver.receiveInput(name);
    }
}
