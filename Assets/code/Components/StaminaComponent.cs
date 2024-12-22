using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    private float currentStamina;
    private float maxStamina;
    private float regenStamina;

    public void Init(float cur, float max, float reg)
    {
        currentStamina = cur;
        maxStamina = max;
        regenStamina = reg;
    }

    public bool Check(float value)
    {
        if (currentStamina < value) return false;
        return true;
    }

    public void Regen()
    {
        currentStamina = currentStamina >= maxStamina ? maxStamina : currentStamina + regenStamina * Time.deltaTime;
    }
    public void Reduce(float value)
    {
        if (currentStamina < value) return;
        currentStamina -= value;
    }
}
