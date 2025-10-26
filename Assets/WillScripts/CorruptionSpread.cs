
using UnityEngine;

public class CorruptionSpread : MonoBehaviour
{
    [Header("Corruption Spread References")]
    [SerializeField] private Transform corruptionSource;// Reference to the source of corruption
    [SerializeField] private GameObject corruptionEffectPrefab;// Prefab for the corruption effect
    [SerializeField] private LayerMask corruptionLayerMask;// Layer mask to define what can be corrupted
    [Header("Corruption Spread Settings")]
    [SerializeField] private float corruptionRate = 0.1f;// Rate at which corruption spreads
    [SerializeField] private float maxCorruptionRadius = 50f;// Maximum radius of corruption spread
    [SerializeField] private float currentCorruptionRadius = 5f;// Current radius of corruption spread
    [SerializeField] private int maxCorruptionEffects = 100;// Maximum number of corruption effects to instantiate
    [SerializeField] private int corruptionEffectsPerSpread = 5;// Number of corruption effects to instantiate per spread
    private int currentCorruptionEffects = 0;// Current number of corruption effects instantiated

    /// <summary>
    /// Spreads corruption from the corruption source, it expands outward.
    /// </summary>
    public void SpreadCorruption()
    {
        Debug.Log("Spreading Corruption...");
        if (currentCorruptionRadius < maxCorruptionRadius)
        {
            Debug.Log("Current Corruption Radius: " + currentCorruptionRadius);
            currentCorruptionRadius += corruptionRate;
            Debug.Log("Increased Corruption Radius to: " + currentCorruptionRadius);
            Collider[] affectedObjects = Physics.OverlapSphere(corruptionSource.position, currentCorruptionRadius);
            Debug.Log("Number of Affected Objects: " + affectedObjects.Length);
            foreach (Collider obj in affectedObjects)
            {
                for (int i = 0; i < corruptionEffectsPerSpread; i++)
                {
                    if (currentCorruptionEffects >= maxCorruptionEffects)
                    {
                        Debug.Log("Maximum Corruption Effects Reached.");
                        return;
                    }
                    Vector3 randomPosition = obj.transform.position + Random.insideUnitSphere * 2f;
                    Instantiate(corruptionEffectPrefab, randomPosition, Quaternion.identity);
                    currentCorruptionEffects++;
                    Debug.Log("Instantiated Corruption Effect at: " + randomPosition);
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(corruptionSource.position, currentCorruptionRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(corruptionSource.position, maxCorruptionRadius);
    }
}
