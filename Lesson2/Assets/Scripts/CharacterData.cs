using UnityEngine;
using System;

public class CharacterData
{
    public CharacterStats stats;

    public void InitializeCharacterData(CharacterSC config_)
    {
        stats = new CharacterStats();
        stats = config_.stats;
        stats.currentHP = config_.stats.currentHP;
        stats.maxHP = config_.stats.maxHP;
    }
}
