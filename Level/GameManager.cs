using UnityEngine;
public class GameManager : MonoBehaviour
{
    public InputManager inputManager;
    MainReceiver receiver = new MainReceiver();
    ActionNames currentAction;
    Level level = new Level(10, 10);
    LevelStatus levelStatus = new LevelStatus(3,4);
    bool phase;
    public Camera _camera;
    void Start()
    {
        UnitFactory factory = new UnitFactory();
        Unit[] units = GameObject.FindObjectsByType<Unit>(FindObjectsSortMode.None);
        level = new Level(10, 10);
        foreach (Unit unit in units)
        {
            factory.fillUnit(unit, "Doubler", "Doubler", "TestClass", 50,100,5,100,100,100);
            level.addUnit(unit);
        }
        Extractor extractor = new Extractor();
        extractor.level = level;
        GameObject temp = GameObject.Find("Tilemap");
        ZoneEffectSystem zoneEffectSystem = temp.GetComponent<ZoneEffectSystem>();
        if(zoneEffectSystem == null)
        {
            Application.Quit();
        }
        temp = GameObject.Find("cursor");
        if(temp == null)
        {
            Debug.Log("No cursor");
            Application.Quit();
        }
        CursorMovementControl movementControl = new CursorMovementControl(temp, _camera);
        temp = GameObject.Find("UISystem");
        UISystem uISystem = temp.GetComponent<UISystem>();
        if (uISystem == null)
        {
            Debug.Log("No uiSystem");
            Application.Quit();
        }
        uISystem.startSystem();
        VolumeCursorData volumeCursor = new VolumeCursorData(zoneEffectSystem, extractor);
        MovingSystem movingSystem = new MovingSystem();
        temp = GameObject.Find("CursorFlat");
        RectTransform cursorFlat = temp.GetComponent<RectTransform>();
        if (cursorFlat == null)
        {
            Debug.Log("No cursorFlat");
            Application.Quit();
        }
        temp.SetActive(false);
        receiver.startSystem(volumeCursor, movementControl, movingSystem, uISystem, cursorFlat, new BattleSystem(level, 
            GetComponent<DeadTransformer>(), levelStatus, movingSystem), _camera);
        inputManager = new InputManager();
        inputManager.actions = new KeyAction[10];
        inputManager.actions[0] = new KeyAction(KeyCode.UpArrow, ActionNames.Up);
        inputManager.actions[1] = new KeyAction(KeyCode.DownArrow, ActionNames.Down);
        inputManager.actions[2] = new KeyAction(KeyCode.LeftArrow, ActionNames.Left);
        inputManager.actions[3] = new KeyAction(KeyCode.RightArrow, ActionNames.Right);
        inputManager.actions[4] = new KeyAction(KeyCode.Return, ActionNames.Confirm);
        inputManager.actions[5] = new KeyAction(KeyCode.Escape, ActionNames.Escape);
    }
    void Update()
    {
        if (levelStatus.phase)
        {
            playerPhase();
        }
    }
    public void playerPhase()
    {
        currentAction = inputManager.generateAction();
        receiver.receiveAction(currentAction);
    }
    public void enemyPhase()
    {

    }
}
