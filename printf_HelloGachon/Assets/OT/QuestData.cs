using System.Collections;
using System.Collections.Generic;

public class QuestData
{
    public string questName;
    public int[] storyObjId;

    public QuestData(string name, int[] storyObj)
    {
        questName = name;
        storyObjId = storyObj;
    }
}
