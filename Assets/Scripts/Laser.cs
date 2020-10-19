using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
  private float _speed = 8.0f;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // Time.deltaTime: time between frames of FPS
    transform.Translate(Vector3.up * _speed * Time.deltaTime);
  }
}
