using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMediator : Mediator
{
    [Inject]
    public GateSignal GateSignal { get; set; }
    [Inject]
    public StickmanSignal StickmanSignal { get; set; }


    public override void OnRegister()
    {
        base.OnRegister();
    }

    public override void OnRemove()
    {
        base.OnRemove();
    }
}
