using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {
    public int CurrentQuest { get; set; }
    public int ActiveQuests { get; set; }
    public Quest[] quests;
    public Text questText;
    public Animator anim;

    public Quest starterQuest;

    private GameObject player;

    void Awake () {
        player = FindObjectOfType<PlayerController>().gameObject;

        quests = new Quest[25];
        CurrentQuest = -1;
        ActiveQuests = 0;

        starterQuest.qst_descr = "Talk to the NPC";
        starterQuest.moneyReward = 10;
        starterQuest.qst_type = Quest.types.travel;

        AddQuest(starterQuest);
	}
	
	void Update () {
        questText.text = (CurrentQuest > -1) ? "Your current quest is:\n" + quests[CurrentQuest].qst_descr : "You have no active quests";
        if (anim.GetBool("isOpen"))
        {
            Invoke("animate", 0.25f);
        }
        
        for (int i = 0; i < ActiveQuests; i++)
        {
            if (quests[i].completed)
            {

            }
        }
	}

    void animate()
    {
        anim.SetBool("isOpen", false);
    }

    public void AddQuest(Quest quest)
    {
        anim.SetBool("isOpen", true);
        quests[ActiveQuests] = quest;
        CurrentQuest = ActiveQuests;
        ActiveQuests++;
    }

    public void RemoveQuest(Quest quest)
    {
        int ind = System.Array.IndexOf(quests, quest);
        if (ActiveQuests == 1) quests[ind] = null;
        for (int i = ind; i < ActiveQuests; i++)
        {

        }
    }

    //update all fetch quests
    public void UpdateFetch()
    {
        foreach(Quest qst in quests)
        {
            if (qst.qst_type == Quest.types.fetch)
            {

            }
        }
    }

    //update all kill quests
    public void UpdateKill()
    {
        foreach (Quest qst in quests)
        {
            if (qst.qst_type == Quest.types.kill)
            {

            }
        }
    }

    //update all collect quests
    public void UpdateCollect()
    {
        foreach (Quest qst in quests)
        {
            if (qst.qst_type == Quest.types.collect)
            {

            }
        }
    }

    //update all travel quests
    public void UpdateTravel()
    {
        foreach (Quest qst in quests)
        {
            if (qst.qst_type == Quest.types.travel)
            {
                if (Vector3.Distance(player.transform.position, qst.travelCompleteCondition) < 10)
                {
                    qst.completed = true;
                }
            }
        }
    }
}
