using System.Collections;
using System.Collections.Generic;
using TT;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CooldownByStatInfo
{
    public string StatID;
}

public class CooldownByStatCondition : BaseCondition, IInfo, IOwn
{
    public CooldownByStatInfo Info { private set; get; }
    Stat stat;
    public void SetInfo(object info)
    {
        if(info is  CooldownByStatInfo) Info = (CooldownByStatInfo)info;
        this.SetSuitableCondition(true);
    }

    public override void ResetCondition()
    {
        base.ResetCondition();
        LeanTween.delayedCall(stat.FinalValue, () => SetSuitableCondition(true));
    }

    public void SetOwn(object own)
    {
        Transform trans = own as Transform;
        var entityStat = trans.GetComponent<EntityStatController>();
        stat = entityStat.GetStatByID(Info.StatID);
    }
}
