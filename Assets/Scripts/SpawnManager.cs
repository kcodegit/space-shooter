using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField]
  private GameObject _enemyPrefab;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(SpawnEnemyRoutine());
  }

  // Update is called once per frame
  void Update()
  {

  }

  // spawn game object every 5 seconds
  IEnumerator SpawnEnemyRoutine()
  {
    while (true)
    {
      Vector3 position = new Vector3(Random.Range(-8f, 8f), 7, 0);
      Instantiate(_enemyPrefab, position, Quaternion.identity);
      yield return new WaitForSeconds(5.0f);
    }
  }

}
