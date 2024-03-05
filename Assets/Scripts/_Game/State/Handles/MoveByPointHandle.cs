using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TT;
using UnityEngine.AI;
using Unity.VisualScripting;
using System.Linq;

[System.Serializable]
public class MoveByPointInfo
{
    public string PointContainerName;
}

public class MoveByPointHandle : BaseHandle, IInfo, IOwn
{
    public MoveByPointInfo Info { private set; get; }

    Transform _own;
    NavMeshAgent agent;
    List<Transform> _points;
    int curIndex = 0;

    public override void Handle()
    {
        int nextIndex = curIndex + 1;
        if (nextIndex >= _points.Count) curIndex = 0;
        agent.destination = _points[curIndex].position;
    }

    public override void ResetHandle()
    {

    }

    public void SetInfo(object info)
    {
        if (info is MoveByPointInfo)
        {
            this.Info = (MoveByPointInfo)info;
        }
    }

    public void SetOwn(object own)
    {
        StateController state = own as StateController;
        _own = state.transform;
        state.Events.RegisterEvent(StateController.StateEventType.OnUpdate, OnUpdate);
        agent = state.GetComponent<NavMeshAgent>();
        var container = GameObject.Find(Info.PointContainerName).transform;

        _points = container.GetComponentsInChildren<Transform>().ToList();
        _points.Remove(container);
    }

    void OnUpdate(StateController state)
    {
        if (Vector3.Distance(_own.position, agent.destination) <= agent.stoppingDistance)
        {
            curIndex += 1;
            if (curIndex >= _points.Count) curIndex = 0;
            agent.destination = _points[curIndex].position;
        }
    }
}
