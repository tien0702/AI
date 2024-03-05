using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;

[System.Serializable]
public class ClickInfo
{
    public bool TypeCheck;
}

public class ClickCondition : BaseCondition, IInfo, IOwn
{
    public ClickInfo Info { private set; get; }

    public void SetInfo(object info)
    {
        if (info is ClickInfo)
        {
            this.Info = (ClickInfo)info;
            this.SetSuitableCondition(!Info.TypeCheck);
        }
    }

    public void SetOwn(object own)
    {
        StateController state = (StateController)own;
        state.Events.RegisterEvent(StateController.StateEventType.OnCheck, (StateController s) => {
            if(Info.TypeCheck)
            {
                SetSuitableCondition(ClickMakerController.Instance.gameObject.activeSelf);
            }
            else
            {
                SetSuitableCondition(!ClickMakerController.Instance.gameObject.activeSelf);
            }
        });
    }
}
