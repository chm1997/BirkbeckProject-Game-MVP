using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    public PlayerInputs playerInputs;
    public Vector2 worldPosition;
    public Vector2 mousePosition;

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
