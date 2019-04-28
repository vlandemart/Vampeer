using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
	[SerializeField]
	private Weapon weapon;
	private BoxCollider2D col;

	void Start()
	{
		col = GetComponent<BoxCollider2D>();
		SetCollider(false);
	}

	public void SetCollider(bool enabled)
	{
		col.enabled = enabled;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		LivingEntity target = other.gameObject.GetComponent<LivingEntity>();
		if (target != null)
			weapon.DealDamage(target);
	}
}
