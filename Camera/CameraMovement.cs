using UnityEngine;

public class CameraMovement : Singleton<CameraMovement>
{
    [SerializeField]private Camera RaycastCamera;
    private Camera _mainCamera;

    private Vector3 _startPoint;
    private Vector3 _startCameraPosition;

    private Plane _plane;

    private bool _canMoveCamera = true;

    [SerializeField] private float _lerpSpeed;

    [SerializeField] private float _left, _right, _up, _down;
    [SerializeField] private float _minZoom, _maxZoom;

    [SerializeField] private float _sencitivity;

    private void Start()
    {
        _mainCamera = Camera.main;
        _plane = new Plane(Vector3.up, Vector3.zero);
        _canMoveCamera = true;
    }

    private void Update()
    {
        MoveCamera();
        Zoom();
           
    }

    private void MoveCamera()
    {
        if (!_canMoveCamera) return;
        if (Input.touchCount >= 2) return;

        Ray ray = RaycastCamera.ScreenPointToRay(Input.mousePosition);

        float distance;
        _plane.Raycast(ray, out distance);

        Vector3 point = ray.GetPoint(distance);

        if (Input.GetMouseButtonDown(0))
        {
            _startPoint = point;
            _startCameraPosition = transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 offset = point - _startPoint;
            transform.position = Vector3.Lerp( transform.position,_startCameraPosition - offset,_lerpSpeed*Time.deltaTime);
        }

        Vector3 currentPosition = transform.position;

        currentPosition.x = Mathf.Clamp(currentPosition.x, _left, _right);
        currentPosition.z = Mathf.Clamp(currentPosition.z, _down, _up);


        transform.position = Vector3.Lerp(transform.position, currentPosition, _lerpSpeed * Time.deltaTime);
    }

    private void Zoom()
    {
        if (Input.touchCount>=2)
        {
            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firstTouchDifference = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchDifference = secondTouch.position - secondTouch.deltaPosition;

            float currentMagnitude = (firstTouch.position - secondTouch.position).magnitude;
            float nextFrameMagnitude = (firstTouchDifference - secondTouchDifference).magnitude;

            float difference = currentMagnitude - nextFrameMagnitude;
            _mainCamera.fieldOfView = Mathf.Clamp(_mainCamera.fieldOfView-difference*0.01f*_sencitivity,_minZoom,_maxZoom);
            RaycastCamera.fieldOfView = Mathf.Clamp(RaycastCamera.fieldOfView - difference * 0.01f * _sencitivity, _minZoom, _maxZoom);       
        }
    }

    public void StopMovement()
    {
        _canMoveCamera = false;
    }

    public void StartMovement()
    {
        _canMoveCamera = true;
    }

    public bool CanSelect()
    {
        return _canMoveCamera;
    }
}
