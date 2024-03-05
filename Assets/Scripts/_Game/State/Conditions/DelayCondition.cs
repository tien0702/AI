using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;

[System.Serializable]
public class DelayInfo
{
    public float DelayTime;
}

public class DelayCondition : BaseCondition, IInfo
{
    public DelayInfo Info { private set; get; }

    public override void ResetCondition()
    {
        base.ResetCondition();
        LeanTween.delayedCall(Info.DelayTime, () => { SetSuitableCondition(true); });
    }

    public void SetInfo(object info)
    {
        if(info is DelayInfo)
        {
            Info = (DelayInfo)info;
        }
        SetSuitableCondition(true);
    }
}
