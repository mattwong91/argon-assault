using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  [SerializeField] InputAction movement;
  [SerializeField] float controlSpeed = 25f;
  [SerializeField] float xRange = 8f;
  [SerializeField] float yRange = 6f;

  [SerializeField] float positionPitchFactor = -2f;
  [SerializeField] float controlPitchFactor = -10f;
  [SerializeField] float positionYawFactor = 3f;
  [SerializeField] float controlRollFactor = -15f;

  float xThrow, yThrow;

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
    ProcessTranslation();
    ProcessRotation();

  }

  void ProcessRotation()
  {
    float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    float pitchDueToControlThrow = yThrow * controlPitchFactor;

    float pitch = pitchDueToPosition + pitchDueToControlThrow;
    float yaw = transform.localPosition.x * positionYawFactor;
    float roll = xThrow * controlRollFactor;

    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
  }

  void ProcessTranslation()
  {
    xThrow = movement.ReadValue<Vector2>().x;
    yThrow = movement.ReadValue<Vector2>().y;

    float xOffset = xThrow * controlSpeed * Time.deltaTime;
    float rawXPos = transform.localPosition.x + xOffset;
    float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

    float yOffset = yThrow * controlSpeed * Time.deltaTime;
    float rawYPos = transform.localPosition.y + yOffset;
    float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
  }
}
