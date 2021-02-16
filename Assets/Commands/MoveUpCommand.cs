using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : Command
{
    public MoveUpCommand()
    {
        this.commandName = "Move Up";
    }

    // Update is called once per frame
    public override void Execute(IMoveable obj)
    {
        obj.MoveUp();
        base.Execute(obj);
    }
}
