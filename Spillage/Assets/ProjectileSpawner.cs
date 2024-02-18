using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> projectilePrefabs = new();
    [SerializeField] private float chargeTime = 0f;
    [SerializeField] private float maxChargeTime = 2f; // Maximum time the shot can be charged
    [SerializeField] private float minForce = 10f; // Minimum force applied to the projectile
    [SerializeField] private float maxForce = 50f; // Maximum force applied to the projectile
    [SerializeField] private ProjectileTypes selectedProjectile = ProjectileTypes.SUGAR;
    public Transform firePoint;

    private void Start()
    {
        firePoint = gameObject.transform;
    }
    private void Update()
    {
        GetInput();
        ChargeAttack();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedProjectile = ProjectileTypes.SUGAR;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedProjectile = ProjectileTypes.ICE;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedProjectile = ProjectileTypes.BOBA;
        }
    }

    private void FireProjectile(ProjectileTypes projType)
    {
        // Calculate the force based on charge time
        float force = Mathf.Lerp(minForce, maxForce, chargeTime / maxChargeTime);

        GameObject selectedPrefab = GetProjectile(projType);

        // Instantiate the projectile at the firePoint position and orientation
        GameObject projectile = Instantiate(selectedPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the projectile and apply force
        if (projectile.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.AddForce(firePoint.forward * force, ForceMode.Impulse);
        }

        // Reset charge time after firing
        chargeTime = 0f;
    }

    private GameObject GetProjectile(ProjectileTypes projType)
    {
        switch (projType)
        {
            case ProjectileTypes.SUGAR:
                return projectilePrefabs[0];
            case ProjectileTypes.ICE:
                return projectilePrefabs[1];
            case ProjectileTypes.BOBA:
                return projectilePrefabs[2];
            default:
                print("Issue returning projectile prefab reference.");
                return projectilePrefabs[1];
        }
    }

    private void ChargeAttack()
    {
        // Start charging when the attack button is pressed down
        if (Input.GetKeyDown(KeyCode.S)) // "Fire1" is typically the left Ctrl or mouse button
        {
            chargeTime = 0f; // Reset charge time
        }

        // Accumulate charge time as long as the button is held down, not exceeding maxChargeTime
        if (Input.GetKey(KeyCode.S))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Min(chargeTime, maxChargeTime);
        }

        // When the button is released, fire the projectile
        if (Input.GetKeyUp(KeyCode.S))
        {
            FireProjectile(selectedProjectile);
        }
    }

}

public enum ProjectileTypes
{
    SUGAR,
    ICE,
    BOBA
}