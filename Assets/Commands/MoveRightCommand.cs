using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : Command
{
    public MoveRightCommand()
    {
        this.commandName = "Move Right";
    }

    // Update is called once per frame
    public override void Execute(IMoveable obj)
    {
        obj.MoveRight();
        base.Execute(obj);
    }
}
