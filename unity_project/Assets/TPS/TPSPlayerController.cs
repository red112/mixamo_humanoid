using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSPlayerController : MonoBehaviour
{
    [Header("Player")]
    public Transform  _playerTransform;
    public GameObject _playerModel;
    public float _moveSpeed;

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        // Move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Player Position
        _playerTransform.position += new Vector3(h, 0, v) * Time.deltaTime * _moveSpeed;


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
