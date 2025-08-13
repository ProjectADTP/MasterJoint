using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _swingKey = KeyCode.Space;
    [SerializeField] private KeyCode _loadKey = KeyCode.L;
    [SerializeField] private KeyCode _fireKey = KeyCode.F;

    public event Action SwingPressed;
    public event Action LoadPressed;
    public event Action FirePressed;

    private void Update()
    {
        if (Input.GetKeyDown(_swingKey))
            SwingPressed?.Invoke();

        if (Input.GetKeyDown(_loadKey))
            LoadPressed?.Invoke();

        if (Input.GetKeyDown(_fireKey))
            FirePressed?.Invoke();
    }
}