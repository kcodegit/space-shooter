using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private float _speed = 4.0f;

  private Player player;

  void Start(){
    player = GameObject.Find("Player").GetComponent<Player>();

    if (player == null)
    {
      Debug.LogError("Player is null");
    }
  }

  void Update()
  {
    transform.Translate(Vector3.down * _speed * Time.deltaTime);

    if (transform.position.y < -5f)
    {
      float randomX = Random.Range(-8f, 8f);
      transform.position = new Vector3(randomX, 8f, 0);
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    // Debug.Log("Hit " + other.transform.name);
    if (other.tag == "Player")
    {
      player.Damage(1);
      Destroy(this.gameObject);
    }

    if (other.tag == "Laser")
    {
      Destroy(other.gameObject);
      player.AddScore(10);
      Destroy(this.gameObject);
    }
  }
}
