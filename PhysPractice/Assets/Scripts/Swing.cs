using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _swingForce = 100f;

    private HingeJoint _hingeJoint;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void OnEnable()
    {
        if (_inputReader != null)
            _inputReader.SwingPressed += ApplySwing;
    }

    private void OnDisable()
    {
        if (_inputReader != null)
            _inputReader.SwingPressed -= ApplySwing;
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
