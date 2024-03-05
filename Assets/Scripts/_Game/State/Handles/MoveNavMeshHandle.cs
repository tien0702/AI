using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;
using UnityEngine.AI;

[System.Serializable]
public class MoveNavMeshInfo
{
    public string StatID;
}

public class MoveNavMeshHandle : IOwn, IInfo
{
    public MoveNavMeshInfo Info { private set; get; }
    Stat _spd;
    NavMeshAgent agent;
    Transform _own;

    public void SetOwn(object own)
    {
        StateController state = own as StateController;
        agent = state.GetComponent<NavMeshAgent>();
        _own = state.transform;
        EntityStatController statController = state.GetComponent<EntityStatController>();
        state.Events.RegisterEvent(StateController.StateEventType.OnUpdate, OnUpdate);
        _spd = statController.GetStatByID(Info.StatID);
    }

    void OnUpdate(StateController state)
    {
        if (NavMesh.SamplePosition(_own.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            int index = 0;
            while ((hit.mask >>= 1) > 0)
            {
                index++;
            }
            float cost = NavMesh.GetAreaCost(index);
            float modifiedSpeed = _spd.FinalValue / cost;

            agent.speed = modifiedSpeed;
        }
    }

    public void SetInfo(object info)
    {
        if(info is MoveNavMeshInfo)
        {
            this.Info = (MoveNavMeshInfo)info;
        }
    }
}
