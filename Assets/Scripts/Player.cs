using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float speed = 2.0f;

  void Start()
  {
    transform.position = new Vector3(0, 0, 0);
  }

  void Update()
  {
    transform.Translate(Vector3.right * speed * Time.deltaTime);
  }
}
