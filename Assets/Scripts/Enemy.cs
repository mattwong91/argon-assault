using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathFX;
  [SerializeField] GameObject hitVFX;

  [SerializeField] int scoreValue = 2;
  [SerializeField] int hitPoints = 3;

  ScoreBoard scoreBoard;
  GameObject parentGameObject;

  void Start()
  {
    scoreBoard = FindObjectOfType<ScoreBoard>();
    parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    AddRigidBody();
  }

  void AddRigidBody()
  {
    Rigidbody rb = gameObject.AddComponent<Rigidbody>();
    rb.useGravity = false;
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
    hitPoints--;
    if (hitPoints >= 1)
    {
      PlayVFX(hitVFX);
    }
  }

  void KillEnemy()
  {
    scoreBoard.IncreaseScore(scoreValue);
    PlayVFX(deathFX);
    Destroy(gameObject);
  }

  void PlayVFX(GameObject vfxToPlay)
  {
    GameObject fx = Instantiate(vfxToPlay, transform.position, Quaternion.identity);
    fx.transform.parent = parentGameObject.transform;
  }

}
