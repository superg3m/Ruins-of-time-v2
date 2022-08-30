using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCoolDown : MonoBehaviour
{
    public float rollCooldownTime = 2f;
    public float rollCooldownTimer = 0f;
    public bool onCooldown = false;
    private void Update()
    {
        if (rollCooldownTimer > 0) rollCooldownTimer -= Time.deltaTime;
        else if (rollCooldownTimer < 0) rollCooldownTimer = 0;
        else 
        {
            onCooldown = false;
        }
    }
    public void SetCooldown()
    {
        onCooldown = true;
        rollCooldownTimer = rollCooldownTime;
    }

}
