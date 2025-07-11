using UnityEngine;
using UnityEngine.InputSystem;  

[RequireComponent(typeof(MoveScript))]
public class GetInputScript : MonoBehaviour
{
    private MoveScript moveScript;
    private GameInputs inputs;
    private Vector2 moveInput = Vector2.zero;

    private void Awake()
    {
        // Récupère le MoveScript sur le même GameObject
        moveScript = GetComponent<MoveScript>();

        // Instancie la classe générée à partir de ton Input Actions Asset
        inputs = new GameInputs();
        
        inputs.Player.Enable();

        // Abonne-toi aux événements de Move (changement + arrêt)
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled  += OnMove;
    }

    // Callback exécuté à chaque changement de la valeur de « Move »
    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        // Envoi les valeurs X/Y vers ton MoveScript
        if (moveScript != null)
        {
            moveScript.Move(moveInput.x, moveInput.y);
        }
    }
}