using UnityEngine;

public class Player : LivingEntity
{
	public override void TakeDamage(float damage, LivingEntity attacker)
	{
		base.TakeDamage(damage, attacker);
		Debug.Log(gameObject.name + " was attacked by " + attacker.name + " for " + damage + " damage.");
	}

	public override void Die(LivingEntity killer)
	{
		base.Die(killer);
		Debug.Log(gameObject.name + " was killed by " + killer.name + ".");
	}
}
