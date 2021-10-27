using UnityEngine;
using Zenject;

public class NpcFactory : INpcFactory
{
    private readonly DiContainer diContainer;

    private const string pathPrincipal = "Principal";
    private const string pathGirl = "Girl";
    private const string pathBaldis = "Baldis";
    private const string pathBully = "Hooligan";
    private const string pathRider = "Rider";

    private Object principalPrefab;
    private Object girlPrefab;
    private Object baldisPrefab;
    private Object bullyPrefab;
    private Object riderPrefab;

    public NpcFactory(DiContainer di)
    {
        diContainer = di;
    }

    public void Load()
    {
        principalPrefab = Resources.Load(pathPrincipal);
        girlPrefab = Resources.Load(pathGirl);
        baldisPrefab = Resources.Load(pathBaldis);
        bullyPrefab = Resources.Load(pathBully);
        riderPrefab = Resources.Load(pathRider);
    }

    public void Create(TypeAI typeAI, Vector3 at)
    {
        switch (typeAI)
        {
            case TypeAI.Baldis:
                diContainer.InstantiatePrefab(baldisPrefab, at,
            Quaternion.identity, null);
                break;
            case TypeAI.Principal:
                diContainer.InstantiatePrefab(principalPrefab, at,
            Quaternion.identity, null);
                break;
            case TypeAI.Bully:
                diContainer.InstantiatePrefab(bullyPrefab, at,
            Quaternion.identity, null);
                break;
            case TypeAI.Girl:
                diContainer.InstantiatePrefab(girlPrefab, at,
            Quaternion.identity, null);
                break;
            case TypeAI.Rider:
                diContainer.InstantiatePrefab(riderPrefab, at,
            Quaternion.identity, null);
                break;
            default:
                break;
        }
    }
}