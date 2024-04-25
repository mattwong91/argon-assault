using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] InputAction movement;

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
    float xThrow = movement.ReadValue<Vector2>().x;
    float yThrow = movement.ReadValue<Vector2>().y;

    float xOffset = 0.2f;

    // transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y, transform.localPosition.z);

    // NOTE My thoughts on how to do this movement, adding vector3 objects together
    Vector3 currentPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    Vector3 offsetPosition = new Vector3(xOffset, 0, 0);

    transform.localPosition = currentPosition + offsetPosition;
  }
}
