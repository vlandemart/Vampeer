using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
	public float Health
	{
		get;
		protected set;
	}

	public void TakeDamage(float damage, LivingEntity attacker)
	{
		Health -= damage;
	}
}
