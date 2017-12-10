using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest  {
    public string qst_descr;
    public bool completed = false;
    public int moneyReward;
    public GameObject[] itemRewards;

    public enum types { fetch, kill, collect, travel };

    public types qst_type;

    /*
     * quests need different complete
     * conditions for different types
     */

    //travel quests
    //get to destination
    public Vector3 travelCompleteCondition;
    //fetch quests
    //get item from location
    public GameObject fetchCompleteCondition;
    //kill quests
    //kill x enemies
    public GameObject killEnemyCondition;
    public int killCompleteCondition;
    //collect quests
    //collect x items
    public GameObject collectItemCondition;
    public int collectCompleteCondition;
}
