using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTask : Task {

    //an action is an empty delegate that takes no parameters and returns nothing
    private readonly System.Action _action;
    public ActionTask(System.Action action)
    {
        _action = action;
    }

    protected override void Init()
    {
        SetStatus(TaskStatus.Success);
        _action();
    }
}
