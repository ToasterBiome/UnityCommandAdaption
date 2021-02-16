using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    public string commandName;
    public Command()
    {
        this.commandName = "Base Command";
    }
    public virtual void Execute(IMoveable obj)
    {
        Log();
    }

    protected virtual void Log()
    {
        Debug.Log(commandName + " executed.");
    }
}
