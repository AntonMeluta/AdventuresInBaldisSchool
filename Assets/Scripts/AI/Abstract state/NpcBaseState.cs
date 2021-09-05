using System.Collections;
using UnityEngine;

public abstract class NpcBaseState
{
    public abstract void EnterState(NpcController npc);

    public abstract void Update(NpcController npc);

    public abstract void OnCollisionEnter(NpcController npc, Collision collision);
}
