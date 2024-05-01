using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathVFX;
  [SerializeField] Transform parent;

  [SerializeField] int scoreValue;

  ScoreBoard scoreBoard;

  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
  }

  void OnParticleCollision(GameObject other)
  {
    scoreBoard.IncreaseScore(scoreValue);

    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parent;

    Destroy(gameObject);
  }
}
