using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public CharacterSC character;
    public CharacterData data;

    public void Start()
    {
        data.InitializeCharacterData(character);
        TakeDamage(data, 5);
    }
    
    [ContextMenu("TakeDamage")]
    public void TakeDamage(CharacterData character, int damage)
    {
        data.stats.currentHP -= damage;
    }
}
