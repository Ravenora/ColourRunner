using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCommand : Command
{
    [Inject]
    public Color GateColor { get; set; }

    public override void Execute()
    {
        Debug.Log(GateColor);
    }
}
