using UnityEngine;

public class Weapon : MonoBehaviour
{
	private float damage = 1f;
	private float attackCooldown = .7f;
	private bool attacking = false;
	private float currentCooldown = 0f;
	private LivingEntity player;
	private Animator animator;
	[SerializeField]
	private WeaponCollider weaponCollider;

	void Start()
	{
		animator = GetComponent<Animator>();
		SetAttacking(false);
		currentCooldown = attackCooldown;
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
			Attack();
		AttackHandling();
		RotateTowardsCursor();
	}

	void RotateTowardsCursor()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
		float angleDeg = (180 / Mathf.PI) * angleRad - 90;

		transform.rotation = Quaternion.Euler(0, 0, angleDeg);
	}

	void AttackHandling()
	{
		if (currentCooldown < attackCooldown)
			currentCooldown += Time.deltaTime;
		else
			SetAttacking(false);
	}

	public void Attack()
	{
		if (currentCooldown < attackCooldown)
			return;
		if (!attacking)
		{
			attacking = true;
			currentCooldown = 0;
			SetAttacking(true);
		}
	}

	void SetAttacking(bool enable)
	{
		attacking = enable;
		animator.SetBool("Attack", enable);
		weaponCollider.SetCollider(enable);
	}

	public void DealDamage(LivingEntity target)
	{
		target.TakeDamage(damage, player);
	}
}
