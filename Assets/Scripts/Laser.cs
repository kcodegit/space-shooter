using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
  private float _speed = 8.0f;
  private bool _isPlayerLaser = true;

  void Update()
  {
    Move(_isPlayerLaser);
  }

  private void Move(bool isUp)
  {
    // Time.deltaTime: time between frames of FPS
    transform.Translate((isUp ? Vector3.up : Vector3.down) * _speed * Time.deltaTime);

    bool isOutOfScreen = isUp ? transform.position.y > 8f : transform.position.y < -8f;
    if (isOutOfScreen)
    {
      if (transform.parent != null)
      {
        Destroy(transform.parent.gameObject);
      }
      Destroy(this.gameObject);
    }
  }

  public void SetEnemyLaser()
  {
    _isPlayerLaser = false;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player" && !_isPlayerLaser)
    {
      Player player = other.GetComponent<Player>();
      if (player != null)
      {
        player.Damage(1);
        Destroy(this.gameObject);
      }
    }
  }
}
