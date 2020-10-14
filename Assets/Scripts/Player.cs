﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private float _speed = 2.0f;

  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
  }

  void Update()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");
    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
    transform.Translate(direction * _speed * Time.deltaTime);
  }
}
