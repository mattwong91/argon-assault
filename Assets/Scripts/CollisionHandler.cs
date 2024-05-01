using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem crashParticles;

  void OnTriggerEnter(Collider other)
  {
    StartCrashSequence();
  }

  void StartCrashSequence()
  {
    crashParticles.Play();
    GetComponent<MeshRenderer>().enabled = false;
    GetComponent<PlayerController>().enabled = false;
    GetComponent<BoxCollider>().enabled = false;
    Invoke("ReloadLevel", loadDelay);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }
}
