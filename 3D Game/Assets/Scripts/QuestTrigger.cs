using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * generic quest trigger
 * might have to change this to
 * different scripts per quest
 * (ie QuestTriggerTravel,
 * QuestTriggerKill, etc)
*/


public class QuestTrigger : MonoBehaviour {
    public Quest quest;
    private GameObject player;
    private QuestManager questManager;

    private void Awake()
    {
        questManager = FindObjectOfType<QuestManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3 && Input.GetKeyDown(KeyCode.E))
        {
            if (!isActivated())
            {
                questManager.AddQuest(quest);
            }
        }
    }

    bool isActivated()
    {
        if (questManager.ActiveQuests == 0) return false;

        for (int i = 0; i < questManager.ActiveQuests; i++)
        {
            if (questManager.quests[i] == quest) return true;
        }

        return false;
    }
}
