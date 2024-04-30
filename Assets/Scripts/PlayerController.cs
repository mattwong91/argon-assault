using UnityEngine;
// NOTE Using new input system
// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
  // [SerializeField] InputAction movement;
  // [SerializeField] InputAction movement;
  [Header("General Setup Settings")]
  [Tooltip("How fast ship moves up and down due to player input")]
  [SerializeField] float controlSpeed = 25f;
  [Tooltip("Max distance ship can travel left and right")]
  [SerializeField] float xRange = 8f;
  [Tooltip("Max distance ship can travel up and down")]
  [SerializeField] float yRange = 6f;

  [Header("Laser gun array")]
  [Tooltip("Add all player lasers here")]
  [SerializeField] GameObject[] lasers;

  [Header("Position based rotation tuning")]
  [Tooltip("Pitch rotation due to position on screen")]
  [SerializeField] float positionPitchFactor = -2f;
  [Tooltip("Yaw rotation due to position on screen")]
  [SerializeField] float positionYawFactor = 3f;

  [Header("Player input based rotation tuning")]
  [Tooltip("Pitch rotation due to player input")]
  [SerializeField] float controlPitchFactor = -10f;
  [Tooltip("Roll rotation due to player input")]
  [SerializeField] float controlRollFactor = -15f;

  float xThrow, yThrow;

  // NOTE Using new input system
  // Lifecycle hooks to enable and disable InputAction system for movement

  // private void OnEnable()
  // {
  //   movement.Enable();
  //   fire.Enable();
  // }

  // private void OnDisable()
  // {
  //   movement.Disable();
  //   fire.Disable();
  // }

  void Update()
  {
    ProcessTranslation();
    ProcessRotation();
    ProcessFiring();
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
    // NOTE Using new input system
    // xThrow = movement.ReadValue<Vector2>().x;
    // yThrow = movement.ReadValue<Vector2>().y;

    xThrow = Input.GetAxis("Horizontal");
    yThrow = Input.GetAxis("Vertical");

    float xOffset = xThrow * controlSpeed * Time.deltaTime;
    float rawXPos = transform.localPosition.x + xOffset;
    float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

    float yOffset = yThrow * controlSpeed * Time.deltaTime;
    float rawYPos = transform.localPosition.y + yOffset;
    float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
  }

  void ProcessFiring()
  {
    // NOTE Using new input system
    // if(fire.ReadValue<float>() > 0.5)
    if (Input.GetButton("Fire1"))
    {
      SetLasersActive(true);
    }
    else
    {
      SetLasersActive(false);
    }
  }

  void SetLasersActive(bool isActive)
  {
    foreach (GameObject laser in lasers)
    {
      var emissionModule = laser.GetComponent<ParticleSystem>().emission;
      emissionModule.enabled = isActive;
    }
  }

}
