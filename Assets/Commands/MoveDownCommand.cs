using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : Command
{
    public MoveDownCommand()
    {
        this.commandName = "Move Down";
    }

    // Update is called once per frame
    public override void Execute(IMoveable obj)
    {
        obj.MoveDown();
        base.Execute(obj);
    }
}
