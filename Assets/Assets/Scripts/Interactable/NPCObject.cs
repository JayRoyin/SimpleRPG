using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string npcName;
    public string[] dialogueContent;

    protected override void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
        Dialogue_UI.Instance.show(npcName, dialogueContent);
    }
}
