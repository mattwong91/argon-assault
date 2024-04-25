using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] InputAction movement;
  [SerializeField] float controlSpeed = 25f;
  [SerializeField] float xRange = 8f;
  [SerializeField] float yRange = 6f;

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

    // NOTE Instructor movement code
    float xOffset = xThrow * controlSpeed * Time.deltaTime;
    float rawXPos = transform.localPosition.x + xOffset;
    float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

    float yOffset = yThrow * controlSpeed * Time.deltaTime;
    float rawYPos = transform.localPosition.y + yOffset;
    float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

  }
}
