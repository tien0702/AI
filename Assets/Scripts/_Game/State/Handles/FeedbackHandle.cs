using System.Collections;
using System.Collections.Generic;
using TT;
using UnityEngine;

[System.Serializable]
public class FeedbackInfo
{
    public string FeedbackId;
}

public class FeedbackHandle : BaseHandle, IInfo, IOwn
{
    public FeedbackInfo Info { get; private set; }

    ParticleSystem particle;
    public override void Handle()
    {
        particle.Play();
        EndHandle();
    }

    public override void ResetHandle()
    {
    }

    public void SetInfo(object info)
    {
        Info = (FeedbackInfo)info;
    }

    public void SetOwn(object own)
    {
        var s = (own as StateController).transform.Find(Info.FeedbackId);
        particle = s.GetComponent<ParticleSystem>();
    }
}
