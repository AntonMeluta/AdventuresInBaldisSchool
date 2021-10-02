using UnityEngine;

[System.Serializable]
public struct SoundDefinition
{
    public SoundEffect effect;
    public AudioClip clip;
}

[System.Serializable]
public enum SoundEffect
{
    TrapInstall,
    CrashGlass,
    MainTheme,
    BellToLean,
    AlarmFire,
    DangerSound,
    LossSound,
    WinSound
}
