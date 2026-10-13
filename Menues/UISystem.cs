using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public Dictionary<UINames, GameObject> userInterfaces = new Dictionary<UINames, GameObject>();
    public GameObject cursor;
    ButtonDisplayer buttonDisplayer = new ButtonDisplayer();
    public void startSystem()
    {
        GameObject gameObj = GameObject.Find("ChoseSkillMenu");
        if (gameObj == null)
        {
            Debug.Log("No skill menu");
            Application.Quit();
        }
        userInterfaces.Add(UINames.ChoseSkillMenu, gameObj);
        gameObj.SetActive(false);
        gameObj = GameObject.Find("InteractionMenu");
        userInterfaces.Add(UINames.ConfirmInteraction, gameObj);
    }
    public void showMenu(UINames name)
    {
        userInterfaces[name].SetActive(true);
        cursor.SetActive(true);
    }
    public void hideMenu(UINames name)
    {
        userInterfaces[name].SetActive(false);
        cursor.SetActive(false);
    }
    public void fillButtons(UINames name, string[] texts, int buttonHeight, int gap, int width)
    {
        GameObject obj = userInterfaces[name];
        buttonDisplayer.displayButtons(obj, texts, buttonHeight, gap, width, cursor);

    } 
}
