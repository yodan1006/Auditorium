using UnityEngine;

namespace Spawneur.Runtime
{
    public class Spawneur : MonoBehaviour
    {
        #region publics
        
        
        #endregion


        #region Unity API

        private void Start()
        {
            InvokeRepeating(nameof(SpawnInCircle), 0f, _spawnInteval);
        }

        #endregion
        
        
        #region Utils
        
        #endregion
        
        
        #region Main functions

        private void SpawnInCircle()
        {
            Vector2 randomSpawn = Random.insideUnitCircle * (_spawnRadius*0.2f);
            Vector2 spawnPositon = new Vector2(transform.position.x + randomSpawn.x, transform.position.y + randomSpawn.y);
            
            GameObject prefab = _prefabsToSpawn[Random.Range(0, _prefabsToSpawn.Length)];
            GameObject spawnedObject = Instantiate(prefab, spawnPositon, transform.rotation);
            spawnedObject.transform.rotation = Quaternion.Euler(0f,0f,0f);
            
            if (_lifeTime > 0f) 
                Destroy(spawnedObject, _lifeTime);
        }
        
        #endregion


        #region private

        [SerializeField] private GameObject[] _prefabsToSpawn;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private Transform _center;
        [SerializeField] private float _spawnInteval;
        [SerializeField] private float _lifeTime;

        #endregion
    }
}
