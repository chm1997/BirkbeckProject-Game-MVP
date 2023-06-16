using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the crosshair object to the position of the mouse pointer relative to the camera
    /// 
    /// </summary>
    
    private PlayerInputs playerInputs;
    private Vector2 worldPosition;
    private Vector2 mousePosition;

    void Start()
    {
        playerInputs = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().playerInputs;
        Cursor.visible = false;
    }

    void Update()
    {
        mousePosition = playerInputs.PlayerInputMap.MousePosition.ReadValue<Vector2>();
        worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 transformPosition = new Vector3(worldPosition.x, worldPosition.y, -8);
        transform.position = transformPosition;
    }
}
