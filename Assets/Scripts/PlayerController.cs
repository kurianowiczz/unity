using UnityEngine;

enum Player
{
    First = 1,
    Second = 2,
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player playerNum;
    [SerializeField] private float speed = 1;
    [SerializeField] private float speed_rotation = 3;

    public static bool isStop;
    [HideInInspector] public int score;


    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (isStop)
        {
            characterController.enabled = false;
            return;
        }
        characterController.enabled = true;

        transform.Rotate(0, Input.GetAxis($"Horizontal{(int)playerNum}") * speed_rotation, 0);
        var forward = transform.TransformDirection(Vector3.forward);
        var currentSpeed = speed * Input.GetAxis($"Vertical{(int)playerNum}");
        characterController.SimpleMove(forward * currentSpeed);
    }
}
