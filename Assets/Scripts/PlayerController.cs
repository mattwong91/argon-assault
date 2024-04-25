using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] InputAction movement;

  void Start()
  {

  }

  // Lifecycle hooks to enable and disable InputAction system for movement
  private void OnEnable()
  {
    movement.Enable();
  }

  private void OnDisable()
  {
    movement.Disable();
  }

  void Update()
  {
    float horizontalThrow = movement.ReadValue<Vector2>().x;
    float verticalThrow = movement.ReadValue<Vector2>().y;
  }
}
