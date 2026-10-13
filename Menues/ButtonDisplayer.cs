using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplayer : MonoBehaviour 
{
    public void displayButtons(GameObject where, string[] texts, int buttonHeight, int gap, int width, GameObject cursor)
    {
        for(int i = 0;i < where.transform.childCount;i++)
        {
            Destroy(where.transform.GetChild(i).gameObject);
        }
        
        int fullHeight = buttonHeight*texts.Length + gap*(texts.Length-1);
        int currentHeight = fullHeight/2 - buttonHeight / 2;
        cursor.GetComponent<Image>().rectTransform.localPosition = new Vector3(0, currentHeight+100, 0);
        GameObject current = new GameObject();
        TextMeshProUGUI meshPro = current.AddComponent<TextMeshProUGUI>();
        current.transform.SetParent(where.transform);
        RectTransform rectTransform = meshPro.rectTransform;
        rectTransform.localPosition = new Vector3(0, currentHeight, 0);
        rectTransform.sizeDelta = new Vector2(width, buttonHeight);
        meshPro.text = texts[0];
        for (int i = 1; i < texts.Length; i++) {
            currentHeight -= buttonHeight + gap;
            current = new GameObject();
            current.AddComponent <TextMeshProUGUI>();
            meshPro = current.GetComponent<TextMeshProUGUI>();
            current.transform.SetParent(where.transform);
            rectTransform = meshPro.rectTransform;
            rectTransform.localPosition = new Vector3(0, currentHeight, 0);
            rectTransform.sizeDelta = new Vector2(width, buttonHeight);
            meshPro.text = texts[i];
            
        }
        
    }
}
