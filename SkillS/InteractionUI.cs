using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InteractionUI : InputReceiver
{
    VolumeCursorData controller;
    UniifiedStorage storage;
    ConfirmInteractionUI confirmInteractionUI;
    MapObject[] knownObjects;
    MainReceiver receiver;
    int currentInteraction;
    public InteractionUI(VolumeCursorData controller, UniifiedStorage storage, 
        ConfirmInteractionUI confirmInteractionUI, MainReceiver receiver)
    {
        this.controller = controller;
        this.storage = storage;
        this.confirmInteractionUI = confirmInteractionUI;
        this.receiver = receiver;
    }
    public void startAction()
    {
        Extractor extractor = controller.extractor;
        EmptyDiamondShape emptyDiamond = new EmptyDiamondShape();
        Unit unit = storage.getUnit();
        Vector2Int[] diamond = emptyDiamond.createDiamond(1, extractor.marker);
        ZoneEffectSystem effectSystem = controller.zoneEffectSystem;
        List<MapObject> mapObjects = new List<MapObject>();
        MapObject obj = extractor.getMapObject();
        if (obj != null)
        {
            mapObjects.Add(obj);
        }
        foreach (Vector2Int vec in diamond)
        {
            obj = extractor.getMapObject();
            if (obj != null)
            {
                mapObjects.Add(obj);
            }
        }
        knownObjects = mapObjects.ToArray();
        effectSystem.fillZone(knownObjects);
    }
    public void receiveInput(ActionNames name)
    {
        if (name.Equals(ActionNames.Confirm))
        {
            MapObject obj = knownObjects[currentInteraction];
            Body body = obj.GetComponent<Body>();
            if (body != null)
            {
                confirmInteractionUI.SetBodyMode(body);
                receiver.showFlatMenu(UINames.ConfirmInteraction);
            }
        }
    }
}
