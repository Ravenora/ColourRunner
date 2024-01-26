using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMediator : Mediator
{
    [Inject]
    public PlayerControllerView View { get; set; }

    [Inject]
    public GateSignal GateSignal { get; set; }
    [Inject]
    public StickmanSignal StickmanSignal { get; set; }


    public override void OnRegister()
    {
        base.OnRegister();
        View.GateSignal.AddListener(OnGateSignal);
        View.StickmanSignal.AddListener(OnStickmanSignal);
    }

    public override void OnRemove()
    {
        base.OnRemove();
        View.GateSignal.RemoveListener(OnGateSignal);
        View.StickmanSignal.RemoveListener(OnStickmanSignal);
    }

    public void OnGateSignal(Color color)
    {
        GateSignal.Dispatch(color);
    }

    public void OnStickmanSignal()
    {
        StickmanSignal.Dispatch();
    }
}
