using UnityEngine;

public interface IDamagable
{
	void Damage(GameObject attacker, Sword causer, DoActionDate data);
}
