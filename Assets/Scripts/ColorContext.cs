using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorContext : MVCSContext
{
    public ColorContext() : base()
    {
    }

    public ColorContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        base.mapBindings();

        commandBinder.Bind<StartSignal>().To<StartCommand>();
    }

    override public void Launch()
    {
        base.Launch();
        //Make sure you've mapped this to a StartCommand!
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
    }
}
