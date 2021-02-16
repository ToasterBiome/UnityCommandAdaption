using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : Command
{
    public MoveLeftCommand()
    {
        this.commandName = "Move Left";
    }

    // Update is called once per frame
    public override void Execute(IMoveable obj)
    {
        obj.MoveLeft();
        base.Execute(obj);
    }
}
