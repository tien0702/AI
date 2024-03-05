using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;
using System;

[System.Serializable]
public class InputKeyConditionInfo
{
    public string KeyName;
}

public class InputKeyCondition : BaseCondition, IInfo, IOwn
{
    public InputKeyConditionInfo Info { private set; get; }

    public void SetInfo(object info)
    {
        if(info is  InputKeyConditionInfo)
        {
            Info = (InputKeyConditionInfo)info;
            this.SetSuitableCondition(false);
        }
    }

    void OnCheck(StateController state)
    {
        if(Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), Info.KeyName)))
        {
            SetSuitableCondition(true);
        }
    }

    public void SetOwn(object own)
    {
        if(own is StateController)
        {
            var state = (StateController)own;
            state.Events.RegisterEvent(StateController.StateEventType.OnCheck, OnCheck);
        }
    }
}
