using UnityEngine;

public class Swing : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private KeyCode _swingKey = KeyCode.Space;
    [SerializeField] private float _swingForce = 100f;

    void Start()
    {
        if (_hingeJoint == null)
            _hingeJoint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (Input.GetKeyDown(_swingKey))
        {
            ApplySwing();
        }
    }

    private void ApplySwing()
    {
        JointMotor motor = _hingeJoint.motor;
        motor.force = _swingForce;

        if (_hingeJoint.angle > 0)
            motor.targetVelocity = -_swingForce; 
        else
            motor.targetVelocity = _swingForce;

        motor.freeSpin = false;
        _hingeJoint.motor = motor;
        _hingeJoint.useMotor = true;

        Invoke(nameof(StopMotor), 0.1f);
    }

    private void StopMotor()
    {
        _hingeJoint.useMotor = false;
    }
}
