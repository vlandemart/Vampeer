using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
	public bool Dead
	{
		get;
		protected set;
	}

	public float Health
	{
		get;
		protected set;
	}

	public virtual void TakeDamage(float damage, LivingEntity attacker)
	{
		if (Dead)
			return;
		Health -= damage;
		if (Health <= 0)
			Die(attacker);
	}

	public virtual void Die(LivingEntity killer)
	{
		Dead = true;
	}
}
