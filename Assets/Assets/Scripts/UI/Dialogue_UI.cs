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
        hide();
        text_name = transform.Find("IMG_name/Text_name").GetComponent<TextMeshProUGUI>();
        text_content = transform.Find("Text_content").GetComponent<TextMeshProUGUI>();
        button_next = transform.Find("BTN_Continue").GetComponent<Button>();
        button_next.onClick.AddListener(this.Next);
    }
    public void show()
    {

        gameObject.SetActive(true);

    }

    public void show(string name,string[] content)
    {
        text_name.text = name; 
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        text_content.text = contentList[0];
        gameObject.SetActive(true);
    }
    public void hide() 
    {
        gameObject.SetActive(false);

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
