using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabApple;
    [SerializeField] private float _radius = 2.8f;
    public List<GameObject> AppleList = new List<GameObject>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    private void Start()
    {
        StartCoroutine(AppleSpawnerCoroutine());
    }

    private IEnumerator AppleSpawnerCoroutine()
    {
        while (true)
        {
            if (AppleList.Count <= 3) 
            {
                SpawnApple();

                yield return new WaitForSeconds(7);
            }
            yield return null;
        }
    }

    private void SpawnApple()
    {
        Vector3 randomSpawnPoint = Random.insideUnitSphere * _radius;
        randomSpawnPoint.y = transform.position.y;
        GameObject apple = Instantiate(_prefabApple, randomSpawnPoint, Quaternion.identity);
        AppleList.Add(apple);
    }

    public void RemoveApple(GameObject apple)
    {
        if (AppleList.Contains(apple))
        {
            AppleList.Remove(apple);
            Destroy(apple);
        }
    }
}
