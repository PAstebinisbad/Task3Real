using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpColorController : MonoBehaviour
{
    public Image powerUpImage;  
    public Color speedBoostColor = Color.blue;
    public Color extraJumpsColor = Color.white;
    public Color freezeEnemiesColor = Color.cyan;
    public Color defaultColor = Color.red; // Default color when no power-up is active

    public void SetPowerUp(string powerUpType)
    {
        switch (powerUpType)
        {
            case "SpeedBoost":
                powerUpImage.color = speedBoostColor;
                break;
            case "ExtraJumps":
                powerUpImage.color = extraJumpsColor;
                break;
            case "FreezeEnemies":
                powerUpImage.color = freezeEnemiesColor;
                break;
            default:
                powerUpImage.color = defaultColor;
                break;
        }

        powerUpImage.SetAllDirty(); 
    }

    public void ResetColor()
    {
        powerUpImage.color = defaultColor;
        powerUpImage.SetAllDirty();  
    }
}
