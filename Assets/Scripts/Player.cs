using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField]
  private float _speed = 3.5f;
  [SerializeField]
  private GameObject _laserPrefab;
  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
  }

  void Update()
  {
    Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    // if I hit the space key, spawn gameObject
    if (Input.GetKeyDown(KeyCode.Space))
    {
      ShootLaser();
    }
  }

  private void ShootLaser()
  {
    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
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
}
