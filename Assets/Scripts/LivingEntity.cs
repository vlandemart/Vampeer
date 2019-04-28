using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
	[SerializeField]
	protected float startingHealth = 3f;

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

	protected virtual void Start()
	{
		Health = startingHealth;
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
