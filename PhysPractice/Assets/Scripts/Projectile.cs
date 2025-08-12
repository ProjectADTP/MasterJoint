using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float destroyTime = 10f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }
}