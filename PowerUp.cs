using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { SpeedBoost, ExtraJumps, FreezeEnemies }
    public PowerUpType powerUpType;

    private PowerUpManager powerUpManager;

    void Start()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();

        if (powerUpManager == null)
        {
            Debug.LogError("PowerUpManager not found in the scene. Please ensure there is a PowerUpManager component in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (powerUpManager == null)
            {
                Debug.LogError("PowerUpManager reference is missing. Cannot activate power-up.");
                return;
            }

            switch (powerUpType)
            {
                case PowerUpType.SpeedBoost:
                    powerUpManager.ActivateSpeedBoost();
                    break;
                case PowerUpType.ExtraJumps:
                    powerUpManager.ActivateExtraJumps();
                    break;
                case PowerUpType.FreezeEnemies:
                    powerUpManager.ActivateFreezeEnemies();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
