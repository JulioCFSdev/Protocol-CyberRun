using UnityEngine;

namespace Camera
{
    public class VisionRotation : MonoBehaviour
    {
        #region Parameters
        
        [SerializeField] private float senCamX;
        [SerializeField] private float senCamY;
        [SerializeField] private MovementController moveController;
        private float mouseX;
        private float mouseY;
        private float rotationX;
        private float rotationY;
        
        #endregion
        
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void Update()
        {
            mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senCamX;
            mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senCamY;
            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        
            transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
            moveController.RotationX(rotationY);
        }
    }    
}
