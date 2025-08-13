using UnityEngine;

public class Catapult : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader _inputReader;

    [Header("Components")]
    [SerializeField] private Transform _spoon;
    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Projectile _projectilePrefab;

    [Header("Catapult Settings")]
    [SerializeField] private float _fireSpring = 100000f;
    [SerializeField] private float _baseSpring = 100f;

    private bool _isLoading = true;
    private bool _isFiring = false;

    private void Awake()
    {
        CreateInitialProjectile();
    }

    private void OnEnable()
    {
        if (_inputReader != null)
        {
            _inputReader.LoadPressed += LoadCatapult;
            _inputReader.FirePressed += FireProjectile;
        }
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        {
            _inputReader.LoadPressed -= LoadCatapult;
            _inputReader.FirePressed -= FireProjectile;
        }
    }

    private void LoadCatapult()
    {
        if (_isLoading && !_isFiring)
            return;

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
        if (!_isLoading && _isFiring)
            return;

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
