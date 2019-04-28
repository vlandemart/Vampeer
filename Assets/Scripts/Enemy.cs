using UnityEngine;

public class Enemy : LivingEntity
{
	[SerializeField]
	private float startingHealth = 3f;

	private void Start()
	{
		Health = startingHealth;
	}

	public override void Die(LivingEntity killer)
	{
		base.Die(killer);
		Debug.Log(gameObject.name + " is dead.");
	}
}
