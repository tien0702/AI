using System.Collections;
using System.Collections.Generic;
using TT;
using UnityEngine;

[System.Serializable]
public class InRangeInfo
{
    public float Range;
}

public class InRangeCondition : BaseCondition, IInfo, IOwn
{
    public InRangeInfo Info { private get; set; }

    

    public void SetInfo(object info)
    {
        if(info is  InRangeInfo)
        {
            this.Info = (InRangeInfo)info;
        }
    }

    public void SetOwn(object own)
    {
        StateController state = own as StateController;

    }

    void OnCheck(StateController state)
    {

    }
}
