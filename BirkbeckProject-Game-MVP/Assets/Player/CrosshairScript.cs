using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    /// <summary>
    /// This class moves the crosshair object to the position of the mouse pointer relative to the camera and handles inputs related to the crosshair
    /// </summary>
    
    private PlayerInputs playerInput;
    private Vector2 mouseWorldPosition;
    private Vector2 mousePosition;

    private void Start()
    {
        // Set up variables required for class functionality
        playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().playerInputs;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        DetermineMouseWorldPosition();
        TransformCursosObject();
        HandlePlayerInteraction();
    }

    private void DetermineMouseWorldPosition()
    {
        //This method works out the correct place to put an object in the game world so that it appears in the cursor position
        mousePosition = playerInput.PlayerInputMap.MousePosition.ReadValue<Vector2>();
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void TransformCursosObject()
    {
        //This method transforms the attached object to the mouse world position
        transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -8);
    }

    private void HandlePlayerInteraction()
    {
        //This method triggers interactable object interfaces when a key is pressed while the attached object is positioned over these objects
        if (playerInput.PlayerInputMap.InteractButton.triggered)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(mouseWorldPosition.x, mouseWorldPosition.y), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<IInteractableObject>() != null)
                {
                    hit.collider.gameObject.SendMessage("RecieveMessage", "");
                }
            }
        }
    }
}
