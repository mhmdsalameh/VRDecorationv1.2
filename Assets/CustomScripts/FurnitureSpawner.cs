using UnityEngine;

public class FurnitureSpawner : MonoBehaviour
{
    public GameObject[] furniturePrefabs; // Array of prefabs
    public Transform playerCamera;        // Player's head position
    public float maxRayDistance = 50f;    // Max distance for raycasting
    public float gridSize = 1f;           // Size of the grid squares

    // Function to spawn a prefab based on index
    public void SpawnFurniture(int prefabIndex)
    {
        if (prefabIndex < 0 || prefabIndex >= furniturePrefabs.Length)
        {
            Debug.LogWarning("Invalid prefab index!");
            return;
        }

        // Raycast to detect the ground
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, LayerMask.GetMask("Ground")))
        {
            // Snap position to grid
            Vector3 spawnPosition = SnapToGrid(hit.point);
            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            // Spawn the furniture
            Instantiate(furniturePrefabs[prefabIndex], spawnPosition, spawnRotation);
        }
        else
        {
            Debug.LogWarning("No valid ground detected for spawning!");
        }
    }

    // Snap a position to the nearest grid point
    private Vector3 SnapToGrid(Vector3 position)
    {
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.z = Mathf.Round(position.z / gridSize) * gridSize;
        return position;
    }
}
