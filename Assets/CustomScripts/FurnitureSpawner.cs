using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{
    public GameObject[] furniturePrefabs;  // Array of furniture prefabs
    public Transform playerCamera;         // Reference to the player's camera
    public float spawnDistance = 2f;       // Distance from the player to spawn the furniture
    public Vector3 spawnOffset = new Vector3(0, 1, 0); // Height offset for spawning furniture

    public void SpawnFurniture(int prefabIndex)
    {
        if (prefabIndex < 0 || prefabIndex >= furniturePrefabs.Length)
        {
            Debug.LogWarning("Invalid prefab index!");
            return;
        }

        // Calculate spawn position in front of the player
        Vector3 spawnPosition = playerCamera.position + playerCamera.forward * spawnDistance + spawnOffset;

        // Spawn the furniture prefab
        Instantiate(furniturePrefabs[prefabIndex], spawnPosition, Quaternion.identity);
    }
}
