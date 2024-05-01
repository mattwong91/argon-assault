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
    ProcessHit();
    KillEnemy();
  }

  void ProcessHit()
  {
    scoreBoard.IncreaseScore(scoreValue);
  }

  void KillEnemy()
  {
    GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
    vfx.transform.parent = parent;

    Destroy(gameObject);
  }


}
