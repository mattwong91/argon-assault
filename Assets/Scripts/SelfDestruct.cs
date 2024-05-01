using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
  [SerializeField] float timeUntilDestroy = 3f;
  void Start()
  {
    Destroy(gameObject, timeUntilDestroy);
  }
}
