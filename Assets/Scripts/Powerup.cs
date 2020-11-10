using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
  [SerializeField]
  private float _speed = 4.0f;

  [SerializeField]
  private PowerupId _powerUpId = PowerupId.TripleShot;

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
      if (player != null)
      {
        switch(_powerUpId){
          case PowerupId.TripleShot:
            player.ActivateTripleShot();
          break;
          case PowerupId.Speed:
            player.ActivateSpeedUp();
          break;
          case PowerupId.Shield:
            player.ActivateShield();
          break;
          default:
          break;
        }
      }

      Destroy(this.gameObject);
    }
  }
}

enum PowerupId: int {
  TripleShot = 0,
  Speed = 1,
  Shield = 2
}
