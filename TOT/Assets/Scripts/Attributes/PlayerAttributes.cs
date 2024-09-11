using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int health;
    public int mana;
    public int attack;
    public int defence;
    public int agility;
    public int magicPower;
    public float minRandom;
    public float maxRandom;

   public void TakeDamage(int amount)
   {
        health -= amount;
        health = Mathf.Max(0, health);
        Vector3 randomness = new Vector3(Random.Range(minRandom, maxRandom), Random.Range(minRandom, maxRandom), Random.Range(minRandom, maxRandom));
        DamagePopUpGenerator.current.CreatePopUp(transform.position + randomness, amount.ToString(), Color.yellow);
   }

   public void DealDamage(GameObject target)
   {
        var enemyatm = target.GetComponent<EnemyAttributes>();
        if (enemyatm != null)
        {
            enemyatm.TakeDamage(attack);
        }
   }
}
