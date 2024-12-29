using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapOnRelease : MonoBehaviour
{
    public float gridSize = 1f; // Size of the grid squares

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Snap to grid
        Vector3 snappedPosition = SnapToGrid(transform.position);
        transform.position = snappedPosition;
    }

    private Vector3 SnapToGrid(Vector3 position)
    {
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.z = Mathf.Round(position.z / gridSize) * gridSize;
        return position;
    }
}
