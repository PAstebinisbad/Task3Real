using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PowerUpColorController colorController;

    public float speedBoostAmount = 2f;
    public float speedBoostDuration = 5f;
    public int extraJumpCount = 2;
    public float freezeDuration = 3f;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        // Ensure colorController is assigned
        if (colorController == null)
        {
            colorController = FindObjectOfType<PowerUpColorController>();
            if (colorController == null)
            {
                //Debug.LogError("PowerUpColorController not found in the scene.");
            }
        }
    }

    public void ActivateSpeedBoost()
    {
        if (colorController != null)
        {
            colorController.SetPowerUp("SpeedBoost");
        }
        StartCoroutine(SpeedBoost());
    }

    public void ActivateExtraJumps()
    {
        if (colorController != null)
        {
            colorController.SetPowerUp("ExtraJumps");
        }
        player.AddExtraJumps(extraJumpCount);
        StartCoroutine(ExtraJumpsRoutine());
    }

    public void ActivateFreezeEnemies()
    {
        if (colorController != null)
        {
            colorController.SetPowerUp("FreezeEnemies");
        }
        StartCoroutine(FreezeEnemies());
    }

    private IEnumerator SpeedBoost()
    {
        player.moveSpeed *= speedBoostAmount;
        yield return new WaitForSeconds(speedBoostDuration);
        player.moveSpeed /= speedBoostAmount;
        if (colorController != null)
        {
            colorController.ResetColor();
        }
    }

    private IEnumerator ExtraJumpsRoutine()
    {
        yield return new WaitForSeconds(freezeDuration); 
        if (colorController != null)
        {
            colorController.ResetColor();
        }
    }

    private IEnumerator FreezeEnemies()
    {
        var enemies = FindObjectsOfType<NewEnemyAI>();

        foreach (var enemy in enemies)
        {
            enemy.FreezeEnemy(true); // Freeze each enemy
        }

        yield return new WaitForSeconds(freezeDuration);

        foreach (var enemy in enemies)
        {
            enemy.FreezeEnemy(false); // Unfreeze each enemy
        }

        if (colorController != null)
        {
            colorController.ResetColor();
        }
    }
}