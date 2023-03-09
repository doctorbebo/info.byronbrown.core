using UnityEngine;
using UnityEngine.InputSystem;

namespace BeboTools.CameraUtil
{
    public class CameraRig : MonoBehaviour
    {
        [Header("Main Attributes")]
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float normalSpeed = 0.5f;
        [SerializeField] private float fastSpeed = 3f;
        [SerializeField] private float movementTime = 5f;
        [SerializeField] private float rotationAmount = 1f;
        [SerializeField] private Vector3 zoomAmount = new Vector3(0, 0.05f, 0.05f);

        [Header("Clamp Position")] 
        [SerializeField] private float minimumXPosition = -10f;
        [SerializeField] private float minimumZPosition = -10f;
        [SerializeField] private float maximumXPosition = 10f;
        [SerializeField] private float maximumZPosition = 10f;
        
        [Header("Clamp Zoom")] 
        [SerializeField] private float minimumZoomAmount = 5f;
        [SerializeField] private float maximumZoomAmount = 30f;
        
        
        [Header("Debug Values")]
        [SerializeField] private Vector3 newPosition;
        [SerializeField] private Quaternion newRotation;
        [SerializeField] private Vector3 newZoom;
        [SerializeField] private Vector3 rotateStartPosition;
        [SerializeField] private Vector3 rotateCurrentPosition;

        private float movementSpeed;
        // Start is called before the first frame update
        private void Start()
        {
            float startZoomPosition = Mathf.Lerp(minimumZoomAmount, maximumZoomAmount, 0.75f);
            cameraTransform.localRotation = Quaternion.Euler(Vector3.right * 45);
            cameraTransform.localPosition = new Vector3(0f, startZoomPosition, -startZoomPosition);
            
            newPosition = transform.position;
            newRotation = transform.rotation;
            newZoom = cameraTransform.localPosition;
        }

        private void Update()
        {
            HandleMovementInput();
        }


        private void HandleMovementInput()
        {
            movementSpeed = Keyboard.current.leftShiftKey.isPressed ? fastSpeed : normalSpeed;
            
            
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
            {
                newPosition += (transform.forward * movementSpeed);
            }

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
            {
                newPosition += transform.forward * -movementSpeed;
            }

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            {
                newPosition += transform.right * movementSpeed;
            }

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            {
                newPosition += transform.right * -movementSpeed;
            }

            if (Keyboard.current.qKey.isPressed)
            {
                newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            }
            
            if (Keyboard.current.eKey.isPressed)
            {
                newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
            }
            
            if (Mouse.current.scroll.y.ReadValue() != 0)
            {
                newZoom += Mouse.current.scroll.y.ReadValue() * zoomAmount;
            }

            if (Mouse.current.middleButton.wasPressedThisFrame)
            {
                rotateStartPosition = Mouse.current.position.ReadValue();
            }

            if (Mouse.current.middleButton.isPressed)
            {
                rotateCurrentPosition = Mouse.current.position.ReadValue();
                Vector3 difference = rotateStartPosition - rotateCurrentPosition;
                rotateStartPosition = rotateCurrentPosition;
                newRotation *= Quaternion.Euler(Vector3.up * (-difference.x/5f));
            }

            newPosition = new Vector3(Mathf.Clamp(newPosition.x, minimumXPosition, maximumXPosition), newPosition.y, Mathf.Clamp(newPosition.z, minimumZPosition, maximumZPosition));
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
            
            newZoom = new Vector3(newZoom.x, Mathf.Clamp(newZoom.y, minimumZoomAmount, maximumZoomAmount), Mathf.Clamp(newZoom.z, -maximumZoomAmount, -minimumZoomAmount));
            cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
        }
        
    }
}
