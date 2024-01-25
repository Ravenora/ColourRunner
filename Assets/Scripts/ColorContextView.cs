using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorContextView : ContextView
{
    void Awake()
    {
        context = new ColorContext(this, true);
        context.Start();
    }
}
