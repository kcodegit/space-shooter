using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField]
  private float _speed = 3.5f;
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private float _fireRate = 0.2f;
  private float _fireableTime = -1f;
  [SerializeField]
  private int _lives = 3;
  private SpawnManager spawnManager;

  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
    spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

    if (spawnManager == null)
    {
      Debug.LogError("SpawnManager is null");
    }
  }

  void Update()
  {
    Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    // if I hit the space key, spawn gameObject
    if (Input.GetKeyDown(KeyCode.Space) && CanFire())
    {
      ShootLaser();
    }
  }

  private bool CanFire()
  {
    return Time.time > _fireableTime;
  }

  private void ShootLaser()
  {
    Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    _fireableTime = Time.time + _fireRate; // to set the time to cool down
  }

  private void Move(float horizontalInput, float verticalInput)
  {
    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * _speed * Time.deltaTime);

    float xPos = transform.position.x >= 11.5f ? -11.5f
      : transform.position.x <= -11.5 ? 11.5f
      : transform.position.x;

    transform.position = new Vector3(xPos, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
  }

  public void Damage(int damageAmount)
  {
    _lives -= damageAmount;
    if (_lives == 0)
    {
      spawnManager.OnPlayerDeath();
      Destroy(this.gameObject);
    }
  }
}
