using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /*
     * need to check for QuestTrigger
     * and add the quest after dialogue
     * is complete
     */
    public Dialogue dialogue;
    public bool convoStarted = false;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3 && Input.GetKeyDown(KeyCode.E) && !convoStarted)
        {
            TriggerDialogue();
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 5) convoStarted = false;
    }

    public void TriggerDialogue()
    {
        convoStarted = true;
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }
}

