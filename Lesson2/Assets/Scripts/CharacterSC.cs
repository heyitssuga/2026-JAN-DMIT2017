using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSC", menuName = "Scriptable Objects/CharacterSC")]
public class CharacterSC : ScriptableObject
{
    public string characterName;
    public CharacterStats stats;
}

[Serializable]
public class CharacterStats
{
    public int maxHP;
    public int currentHP;
    public int maxSP;
    public int currentSP;
    public int ATK;
    public int DEF;
    public int MATK;
    public int MDEF;
    public int AGI;
}
