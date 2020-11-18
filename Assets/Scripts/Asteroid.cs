using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  [SerializeField]
  private float _speed = 18.0f;
  [SerializeField]
  private GameObject _explosionPrefab;

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
      Destroy(this.gameObject, 0.2f);
    }
  }
}
