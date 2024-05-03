using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] GameObject deathVFX;
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
    PlayVFX(deathVFX);
    Destroy(gameObject);
  }

  void PlayVFX(GameObject vfxToPlay)
  {
    GameObject vfx = Instantiate(vfxToPlay, transform.position, Quaternion.identity);
    vfx.transform.parent = parentGameObject.transform;
  }

}
