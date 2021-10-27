using UnityEngine;

public interface INpcFactory
{
    void Load();
    void Create(TypeAI typeAI, Vector3 at);
}
