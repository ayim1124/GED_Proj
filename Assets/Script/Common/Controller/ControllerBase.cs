using UnityEngine;
using System.Collections;

public abstract class ControllerBase {
    public KeyCode Up { get; protected set; }
    public KeyCode Down { get; protected set; }
    public KeyCode Left { get; protected set; }
    public KeyCode Right { get; protected set; }
    public KeyCode Fire { get; protected set; }
    public KeyCode Jump { get; protected set; }
    public KeyCode Skill { get; protected set; }

    public ControllerBase() {
        Initial();
    }
    protected abstract void Initial();
}
