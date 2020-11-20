using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  [SerializeField]
  private float _speed = 18.0f;
  [SerializeField]
  private GameObject _explosionPrefab;
  private SpawnManager spawnManager;

  private void Start()
  {
    spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    if (spawnManager == null)
    {
      Debug.LogError("SpawnManager is null");
    }
  }

  // Update is called once per frame
  void Update()
  {
    transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
  }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.tag == "Laser")
    {
      Destroy(other.gameObject);
      Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
      spawnManager.StartSpawning();

      Destroy(this.gameObject, 0.2f);
    }
  }
}
