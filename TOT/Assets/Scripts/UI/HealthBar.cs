using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
//     public Slider healthSlider;
//     public Slider easeHealthSlider;
//     public float health;
//     public float lerpSpeed;
//     public float timeToRecoverHealth;
//     public float healthRecoveryRate;
//     public float recoveryInterval;
//     [SerializeField] PlayerAttributes atm;
//     // Start is called before the first frame update
//     void Start()
//     {
//      health = atm.health; 
//      healthSlider.maxValue = atm.health;
//      easeHealthSlider.maxValue = atm.health;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(healthSlider.value != health)
//         {
//             healthSlider.value = health;
//         }

//         if(Input.GetKeyDown(KeyCode.O))
//         {
//             takeDamage(10);
//         }
 
//         if(healthSlider.value != easeHealthSlider.value)
//         {
//             easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
//         }
//     }

//     void takeDamage(float damage)
//     {
//         health -= damage; 
//     }
// }
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float lerpSpeed;
    public float timeToRecoverHealth;
    public float healthRecoveryRate;
    public float recoveryInterval;
    public float health;
    [SerializeField] private PlayerAttributes playeratm;

    void Start()
    {
        if (playeratm != null)
        {
            health = playeratm.health;
            healthSlider.maxValue = playeratm.health;
            easeHealthSlider.maxValue = playeratm.health;
            healthSlider.value = health;
        }
    }

    void Update()
    {
        if (healthSlider.value != playeratm.health)
        {
            healthSlider.value = playeratm.health;
        }

        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, healthSlider.value, lerpSpeed);
        }
    }
}