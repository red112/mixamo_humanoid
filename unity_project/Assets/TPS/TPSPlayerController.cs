using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayerController : MonoBehaviour
{
    [Header("Player")]
    public Transform  _playerTransform;
    public GameObject _playerModel;

    [Header("Camera")]
    public Transform _camera;
    public Transform _camera_target;
    public float _minDistance;
    public float _maxDistance;
    public float _curDistance;
    public float _minElevation;
    public float _maxElevation;
    public float _curElevation;
    public float _curAzimuth;

    [Header("Movement")]
    public float _moveSpeed;
    public Animator  _animator;


    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = _playerTransform.GetComponentInChildren<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("DDDD");
            _animator.SetTrigger("trgJump");
            //rigidbody.AddForce(Vector3.up*10, ForceMode.Impulse);
        }
    }

    private void LateUpdate()
    {
        // Player
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h!=0 || v!=0)
        {
            // Player direction
            Vector3 input_movement = new Vector3(h, 0, v);
            _playerTransform.rotation = Quaternion.AngleAxis(Vector3.SignedAngle(Vector3.forward, input_movement, Vector3.up), Vector3.up) * Quaternion.AngleAxis(_curAzimuth, Vector3.up);

            // Player Position
            Vector3 rotated_movement = Quaternion.AngleAxis(_curAzimuth, Vector3.up) * input_movement;
            _playerTransform.position += rotated_movement * Time.deltaTime * _moveSpeed;

            // Animation
            _animator.SetBool("bIsRun", input_movement.magnitude > 0.1);

            // Jump
         //   if (Input.GetButtonDown("Jump"))

        }


        //Zoom
        _curDistance += Input.mouseScrollDelta.y;
        _curDistance = Mathf.Clamp(_curDistance, _minDistance, _maxDistance);

        //Rotate delta
        if(Input.GetMouseButton(0))
        {
            _curAzimuth += Input.GetAxis("Mouse X");
            if (_curAzimuth > 180.0f)
                _curAzimuth = -360.0f + _curAzimuth;
            else if(_curAzimuth < -180.0f)
                _curAzimuth = 360.0f + _curAzimuth;

            _curElevation -= Input.GetAxis("Mouse Y");
            _curElevation = Mathf.Clamp(_curElevation, _minElevation, _maxElevation);
        }
        //Rotate update
        //Elevation
        Vector3 curPos = Quaternion.AngleAxis(_curElevation, Vector3.right) * new Vector3(0, 0, -_curDistance);
        //Azimuth
        curPos = Quaternion.AngleAxis(_curAzimuth, Vector3.up) * curPos;
        //Offset
        _camera.position = _camera_target.position + curPos;

        //Aim target
        _camera.LookAt(_camera_target.position);
    }
}
