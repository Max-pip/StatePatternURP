using UnityEngine;

public class LifeRadius : MonoBehaviour
{
    [field: SerializeField] public float LimitRadius { get; private set; } = 5f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, LimitRadius);
    }

    public Vector3 SpawnRandomPointWithinRadius(float playerPosYAxis)
    {
        Vector3 randomPointPos = Random.insideUnitSphere * LimitRadius;
        randomPointPos = new Vector3(randomPointPos.x, playerPosYAxis, randomPointPos.z);
        return randomPointPos;
    }
}
