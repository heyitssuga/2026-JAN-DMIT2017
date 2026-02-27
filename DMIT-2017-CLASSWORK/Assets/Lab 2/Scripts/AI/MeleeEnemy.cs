using UnityEngine;

public class MeleeEnemy : Enemy
{
    public override void Attack()
    {
        Debug.Log("hit");
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }
}
