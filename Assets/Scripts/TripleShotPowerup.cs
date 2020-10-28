using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
  [SerializeField]
  private float _speed = 4.0f;

  void Start()
  {

  }

  void Update()
  {
    transform.Translate(Vector3.down * _speed * Time.deltaTime);

    if (transform.position.y < -5f)
    {
      Destroy(this.gameObject);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Player player = other.transform.GetComponent<Player>();
      if (Player != null)
      {
        player.ActivateTripleShot();
      }

      Destroy(this.gameObject);
    }
  }
}
