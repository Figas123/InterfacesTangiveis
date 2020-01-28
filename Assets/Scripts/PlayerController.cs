using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Vector3 Movement = Vector3.zero;
    private CharacterController CharacterController;

    public float MoveSpeed = 10;
    public float JumpSpeed = 10;
    public float Gravity = 20;

    public void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (CharacterController.isGrounded)
        {
            Movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Movement = transform.TransformDirection(Movement);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                Movement = (Movement * MoveSpeed) / 2;
            }

            else
            {
                Movement *= MoveSpeed;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Movement.y = JumpSpeed;
            }
        }

        else
        {
            Movement.x = Input.GetAxis("Horizontal") * MoveSpeed;
            Movement.z = Input.GetAxis("Vertical") * MoveSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {

                Movement = transform.TransformDirection(Movement.x / 2, Movement.y, Movement.z / 2);
            }

            else
            {
                Movement = transform.TransformDirection(Movement);
            }
        }

        Movement.y = Movement.y - (Gravity * Time.deltaTime);
        CharacterController.Move(Movement * Time.deltaTime);
    }
}
