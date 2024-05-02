using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathVFX;
  [SerializeField] GameObject hitVFX;
  [SerializeField] Transform parent;

  [SerializeField] int scoreValue;
  [SerializeField] int hitPoints = 2;

  ScoreBoard scoreBoard;

  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
  }

  void OnParticleCollision(GameObject other)
  {
    ProcessHit();
    if (hitPoints < 1)
    {
      KillEnemy();
    }
  }

  void ProcessHit()
  {
    scoreBoard.IncreaseScore(scoreValue);
    hitPoints--;
    if (hitPoints >= 1)
    {
      PlayVFX(hitVFX);
    }
  }

  void KillEnemy()
  {
    PlayVFX(deathVFX);
    Destroy(gameObject);
  }

  void PlayVFX(GameObject vfxToPlay)
  {
    GameObject vfx = Instantiate(vfxToPlay, transform.position, Quaternion.identity);
    vfx.transform.parent = parent;
  }

}
