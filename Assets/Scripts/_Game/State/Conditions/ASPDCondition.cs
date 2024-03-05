using System.Collections;
using System.Collections.Generic;
using TT;
using UnityEngine;

public class ASPDCondition : BaseCondition, IOwn
{
    EntityStatController entityStat;

    Stat aspd;

    public void SetOwn(object own)
    {
        StateController state = own as StateController;
        entityStat = state.GetComponent<EntityStatController>();
        aspd = entityStat.GetStatByID("ASPD");
        SetSuitableCondition(true);
    }

    public override void ResetCondition()
    {
        base.ResetCondition();

        LeanTween.delayedCall(1000f / aspd.FinalValue, () => { SetSuitableCondition(true); });
    }
}
