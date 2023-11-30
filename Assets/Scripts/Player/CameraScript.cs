using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float _pitch;
    private float _sensitivity;
    
    private Transform _transform;

    public static float YInput;
    
    private void Awake()
    {
        _sensitivity = PlayerMovement.Sensitivity;
        Cursor.lockState = CursorLockMode.Locked;
        _transform = this.transform;
    }
    
    
    private void Update()
    {
        //Gets Mouse Movement
        _pitch = YInput * _sensitivity;
        _pitch = transform.eulerAngles.x - _pitch;
        
        //Corrects _pitch units
        if (_pitch >= 180)
        {
            _pitch -= 360;
        }
        if (_pitch <= -180)
        {
            _pitch += 360;
        }
        _pitch = Mathf.Clamp(_pitch, -88, 88);
        
        _transform.eulerAngles = new Vector3(_pitch, _transform.eulerAngles.y, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
