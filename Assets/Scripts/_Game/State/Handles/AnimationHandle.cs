using System.Collections;
using System.Collections.Generic;
using TT;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandle : BaseHandle, IOwn
{
    Animator animator;
    NavMeshAgent agent;
    public override void Handle()
    {
        ClickMakerController.Instance.gameObject.SetActive(false);
        agent.destination = agent.transform.position;
    }

    public override void ResetHandle()
    {

    }

    void OnUpdate(StateController state)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            EndHandle();
    }

    public void SetOwn(object own)
    {
        StateController state = own as StateController;
        animator = state.GetComponentInChildren<Animator>();
        state.Events.RegisterEvent(StateController.StateEventType.OnUpdate, OnUpdate);
        agent = state.GetComponent<NavMeshAgent>();
    }
}
