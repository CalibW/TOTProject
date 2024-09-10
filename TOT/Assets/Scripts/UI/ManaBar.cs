using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaSlider;
    public Slider easeManaSlider;
    [SerializeField] PlayerAttributes atm;
    public float mana;
    public float manaDashLossRate;
    public float manaFireBallLossRate;
    public float timeToLoseMana;
    public float timeToRecoverMana;
    public float manaRecoveryRate;
    public float lerpSpeed;
    public float recoveryInterval;
    

    void Start()
    {
        mana = atm.mana;
        manaSlider.maxValue = atm.mana;
        easeManaSlider.maxValue = atm.mana;
        StartCoroutine(RecoverManaOverTime());
    }

    void Update()
    {
        if (manaSlider.value != mana)
        {
            manaSlider.value = mana;
        }

        if (manaSlider.value != easeManaSlider.value)
        {
            easeManaSlider.value = Mathf.Lerp(easeManaSlider.value, manaSlider.value, lerpSpeed);
        }
    }

    public void loseDashMana(float spent)
    {
        mana -= spent;
        mana = Mathf.Clamp(mana, 0, atm.mana);
    }

    public void loseShootMana(float spent)
    {
        mana -= spent;
        mana = Mathf.Clamp(mana, 0, atm.mana);
    }

    public IEnumerator RecoverManaOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(recoveryInterval);
            RecoverMana();
        }
    }

    public void RecoverMana()
    {
        if (mana < atm.mana)
        {
            mana += atm.magicPower * manaRecoveryRate;
        }
        else if (mana > atm.mana)
        {
            mana = atm.mana;
        }
        else if (mana == atm.mana)
        {
            Debug.Log("Mana is Recovered");
        }
    }
}