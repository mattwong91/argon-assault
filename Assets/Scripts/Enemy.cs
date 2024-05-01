using UnityEngine;

public class Enemy : MonoBehaviour
{
  void OnParticleCollision(GameObject other)
  {
    Debug.Log($"{name} is hit by {other.gameObject.name}");
    Destroy(gameObject);
  }
}
