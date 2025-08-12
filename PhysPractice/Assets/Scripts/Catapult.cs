using UnityEngine;
using UnityEngine.ProBuilder;

public class Catapult : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform _spoon;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;

    [Header("Controls")]
    [SerializeField] private KeyCode _loadKey = KeyCode.L;
    [SerializeField] private KeyCode _fireKey = KeyCode.F;

    [Header("Catapult Settings")]
    [SerializeField] private float _fireSpring = 100000f;
    [SerializeField] private float _baseSpring = 100f;

    private bool _isLoading = true;
    private bool _isFiring = false;

    private void Awake()
    {
        CreateInitialProjectile();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(_loadKey) && !_isLoading && _isFiring)
        {
            LoadCatapult();
        }

        if (Input.GetKeyDown(_fireKey) && _isLoading && !_isFiring)
        {
            FireProjectile();
        }
    }

    private void LoadCatapult()
    {
        if (_spoon != null && _spoon.TryGetComponent(out SpringJoint joint) != false)
        {
            joint.spring = _baseSpring;
        }

        CreateInitialProjectile();

        _isLoading = true;
        _isFiring = false;
    }

    private void FireProjectile()
    {
        if (_spoon != null && _spoon.TryGetComponent(out SpringJoint joint) != false)
        {
            joint.spring = _fireSpring;
        }

        _isLoading = false;
        _isFiring = true;
    }

    private void CreateInitialProjectile()
    {
        if (_projectilePrefab != null && _projectileSpawnPoint != null)
        {
            Instantiate(_projectilePrefab, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
        }
    }
}
