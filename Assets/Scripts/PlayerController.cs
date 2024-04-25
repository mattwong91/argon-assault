using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] InputAction movement;
  [SerializeField] float controlSpeed = 25f;

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

    float xOffset = xThrow * controlSpeed * Time.deltaTime;
    float yOffset = yThrow * controlSpeed * Time.deltaTime;

    // NOTE Instructor movement code
    // float newXPos = transform.localPosition.x + xOffset;
    // float newYPos = transform.localPosition.y + xOffset;
    // transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);

    // NOTE My thoughts on how to do this movement, adding vector3 objects together
    Vector3 currentPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    Vector3 offsetPosition = new Vector3(xOffset, yOffset, 0);

    transform.localPosition = currentPosition + offsetPosition;
  }
}
