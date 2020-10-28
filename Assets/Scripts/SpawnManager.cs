using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField]
  private GameObject _enemyPrefab;
  [SerializeField]
  private GameObject _enemyContainer;
  [SerializeField]
  private GameObject _tripleShotPUPrefab;
  [SerializeField]
  private GameObject _itemContainer;
  private bool _stopSpawning = false;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(SpawnEnemyRoutine());
    StartCoroutine(SpawnTripleShotPURoutine());
  }

  // Update is called once per frame
  void Update()
  {

  }

  // spawn game object every 5 seconds
  IEnumerator SpawnEnemyRoutine()
  {
    while (!_stopSpawning)
    {
      GameObject newEnemy = SpawnObject(_enemyPrefab, GetRandomPosition());
      newEnemy.transform.parent = _enemyContainer.transform;
      yield return new WaitForSeconds(5.0f);
    }
  }

  IEnumerator SpawnTripleShotPURoutine()
  {
    while (!_stopSpawning)
    {
      GameObject newItem = SpawnObject(_tripleShotPUPrefab, GetRandomPosition());
      newItem.transform.parent = _itemContainer.transform;
      yield return new WaitForSeconds(8.0f);
    }
  }

  private GameObject SpawnObject(GameObject prefab, Vector3 position)
  {
    return Instantiate(prefab, position, Quaternion.identity);
  }

  private Vector3 GetRandomPosition()
  {
    return new Vector3(Random.Range(-8f, 8f), 7, 0);
  }

  public void OnPlayerDeath()
  {
    _stopSpawning = true;
  }

}
