using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField]
  private float _speed = 3.5f;
  private float _speedMultiplier = 2;
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private GameObject _tripleShotPrefab;
  [SerializeField]
  private GameObject _shieldVisualizer;
  [SerializeField]
  private float _fireRate = 0.2f;
  private float _fireableTime = -1f;
  [SerializeField]
  private int _lives = 3;
  private SpawnManager spawnManager;
  [SerializeField]
  private bool _isTripleShotEnabled = false;
  [SerializeField]
  private bool _isSpeedUpEnabled = false;
  [SerializeField]
  private bool _isShieldEnabled = false;

  private int _score = 0;

  private UIManager UIManager;

  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
    spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    if (spawnManager == null)
    {
      Debug.LogError("SpawnManager is null");
    }
    if (UIManager == null)
    {
      Debug.LogError("UIManager is null");
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
    if (_isTripleShotEnabled)
    {
      Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
    }
    else
    {
      Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
    }
    _fireableTime = Time.time + _fireRate; // to set the time to cool down
  }

  private void Move(float horizontalInput, float verticalInput)
  {
    float _speedToSet = _isSpeedUpEnabled ? _speed * _speedMultiplier : _speed;

    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * _speedToSet * Time.deltaTime);

    float xPos = transform.position.x >= 11.5f ? -11.5f
      : transform.position.x <= -11.5 ? 11.5f
      : transform.position.x;

    transform.position = new Vector3(xPos, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
  }

  public void Damage(int damageAmount)
  {
    if(_isShieldEnabled){
      DeactivateShield();
      return;
    }

    _lives -= damageAmount;
    if (_lives == 0)
    {
      spawnManager.OnPlayerDeath();
      Destroy(this.gameObject);
    }
  }

  public void AddScore(int score){
    _score += score;
    UIManager.UpdateScoreText(_score);
  }

  public void ActivateTripleShot()
  {
    _isTripleShotEnabled = true;
    StartCoroutine(TripleShotPowerDownRoutine());
  }

  public void ActivateSpeedUp()
  {
    _isSpeedUpEnabled = true;
    StartCoroutine(SpeedUpExpireRoutine());
  }

  public void ActivateShield()
  {
    _isShieldEnabled = true;
    _shieldVisualizer.SetActive(true);
  }
  
  public void DeactivateShield()
  {
    _isShieldEnabled = false;
    _shieldVisualizer.SetActive(false);
  }

  IEnumerator TripleShotPowerDownRoutine()
  {
    yield return new WaitForSeconds(5.0f);
    _isTripleShotEnabled = false;
  }

  IEnumerator SpeedUpExpireRoutine()
  {
    yield return new WaitForSeconds(5.0f);
    _isSpeedUpEnabled = false;
  }
}
