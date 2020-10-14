using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private float _speed = 3.5f;

  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
  }

  void Update()
  {
    Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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
