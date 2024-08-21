using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
   [SerializeField] private Coin _prefab;
   [SerializeField] private List<Transform> _spawnPoint;
   [SerializeField] private float _delay;
   
   private Coroutine _coroutine;
   private WaitForSeconds _delayStep;
   private int _nextSpawnPoint = 0;

   private void Awake()
   {
      _delayStep = new WaitForSeconds(_delay);
      StartCoroutine(Spawning());
   }

   private IEnumerator Spawning()
   {
      while (_nextSpawnPoint < _spawnPoint.Count)
      {
         Instantiate(_prefab, _spawnPoint[_nextSpawnPoint].position, Quaternion.identity);
         _nextSpawnPoint++;
         
         yield return _delayStep;
      }
   }
}
