using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private float _speed = 4.0f;
  [SerializeField]
  private GameObject _explosionPrefab;

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
      Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
      Destroy(this.gameObject);
    }

    if (other.tag == "Laser")
    {
      Destroy(other.gameObject);
      player.AddScore(10);
      Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
      // Just in case we delay the destroy enemy object
      Destroy(this.gameObject.GetComponent<Collider2D>());
      Destroy(this.gameObject);
    }
  }
}
