using UnityEngine;
using UnityEngine.EventSystems;

public enum SelectionState
{
    QuickActions,
    Selected,
    None
}

public class Management : MonoBehaviour
{
    private Camera _mainCamera;

    private Vector3 _cameraStartPos;

    [SerializeField] private SelectionState SelectionState;

    [SerializeField] private SelectableObject _currentSelectableObject;

    private void Start()
    {
        SelectionState = SelectionState.None;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _cameraStartPos = _mainCamera.transform.position;

        }

        if (Input.GetMouseButtonUp(0))
        {
        
            if (!CheckCameraMovement(_mainCamera.transform.position)) return;
            TrySelect();
        }

    }

    private void TrySelect()
    {
        
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (!Physics.Raycast(ray, out hitInfo)) return;

        if (SelectionState == SelectionState.Selected)
        {
            return;
        }

        SelectableCollider selectableCollider = hitInfo.collider.GetComponent<SelectableCollider>();
        if (selectableCollider)
        {
            if (selectableCollider.SelectableObject == _currentSelectableObject && EventSystem.current.IsPointerOverGameObject())
            {
                Deselect();
                return;
            }
            selectableCollider.SelectableObject.Select();
            _currentSelectableObject = selectableCollider.SelectableObject;
            SelectionState = SelectionState.QuickActions;
        }
        else
        {
            Deselect();
        }

    }
    public void Deselect()
    {
        if (_currentSelectableObject)
        {
            _currentSelectableObject.Deselect();
            _currentSelectableObject = null;
        }
        SelectionState = SelectionState.None;
        enabled = true;

    }

    private bool CheckCameraMovement(Vector3 _currentCameraPos)
    {
        float distance = Vector3.Distance(_currentCameraPos, _cameraStartPos);
        if (distance < 0.1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeState()
    {
        SelectionState = SelectionState.Selected;
        enabled = false;
    }
}
