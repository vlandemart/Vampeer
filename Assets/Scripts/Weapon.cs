using UnityEngine;

public class Weapon : MonoBehaviour
{
	private float damage = 1f;
	private float attackCooldown = .4f;

	private int attack = 0;
	private float attackOffset = 0f;
	private float attackSpeed = 4.3f;

	private bool attacking = false;
	private float currentCooldown = 0f;
	private LivingEntity player;
	[SerializeField]
	private Animator hitAnimation;
	[SerializeField]
	private WeaponCollider weaponCollider;

	void Start()
	{
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
		float angleDeg = (180 / Mathf.PI) * angleRad - 90 + attackOffset;

		transform.rotation = Quaternion.Euler(0, 0, angleDeg);
	}

	void AttackHandling()
	{
		if (currentCooldown < attackCooldown)
			currentCooldown += Time.deltaTime;
		else
			SetAttacking(false);


		int sign = (attack % 2 == 0) ? 1 : -1;
		if (attacking)
		{
			if ((sign == 1 && attackOffset < 50) || (sign == -1 && attackOffset > -50))
				attackOffset += attackSpeed * attackSpeed * sign;
			else
				transform.localScale = new Vector3(sign * 1, 1, 1);
		}
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
		weaponCollider.SetCollider(enable);
		if (enable)
			attack++;
		if (hitAnimation != null)
			hitAnimation.SetBool("Attack", enable);
	}

	public void DealDamage(LivingEntity target)
	{
		target.TakeDamage(damage, player);
	}
}
