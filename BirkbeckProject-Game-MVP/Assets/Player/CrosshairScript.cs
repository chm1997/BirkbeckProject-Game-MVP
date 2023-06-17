
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the crosshair object to the position of the mouse pointer relative to the camera
    /// </summary>
    
    private PlayerInputs playerInput;
    private Vector2 mouseWorldPosition;
    private Vector2 mousePosition;

    void Start()
    {
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().playerInputs;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        mousePosition = playerInput.PlayerInputMap.MousePosition.ReadValue<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -8);
    }
}
