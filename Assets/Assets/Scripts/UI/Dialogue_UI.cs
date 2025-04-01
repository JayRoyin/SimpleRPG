using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_UI : MonoBehaviour
{
    public static Dialogue_UI Instance { get; private set; }

    public TextMeshProUGUI text_name;
    public TextMeshProUGUI text_content;
    public Button button_next;


    public List<string> contentList;
    private int contentIndex = 0;

    private GameObject uiGameObject;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); return;
        }

        Instance = this;
    }
    private void Start()
    {
        text_name = transform.Find("DialogueUI/IMG_name/Text_name").GetComponent<TextMeshProUGUI>();
        text_content = transform.Find("DialogueUI/Text_content").GetComponent<TextMeshProUGUI>();
        button_next = transform.Find("DialogueUI/BTN_Continue").GetComponent<Button>();
        button_next.onClick.AddListener(this.Next);
        uiGameObject = transform.Find("DialogueUI").gameObject;
        hide();
    }
    public void show()
    {

        uiGameObject.SetActive(true);

    }

    public void show(string name,string[] content)
    {
        text_name.text = name; 
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        text_content.text = contentList[0];
        uiGameObject.SetActive(true);
    }
    public void hide() 
    {
        uiGameObject.SetActive(false);

    }  
    private void Next()
    {
        contentIndex++;
        if (contentIndex >= contentList.Count)
        {
            hide();
            return;
        }
        text_content.text = contentList[contentIndex];
    }
}
