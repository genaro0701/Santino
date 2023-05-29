using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private PlayerController2D m_PlayerController;
    [SerializeField] private PlayerVFX movementDust;
    [SerializeField] private float m_RunSpeed = 30f;

    [HideInInspector] public bool jump;
    [HideInInspector] public int currentlevel, savedlevel;
    [HideInInspector] public float joystickHorizontal;

    private float m_HorizontalMove;
    private float move;

    private void Update()
    {
        //Horizontal movement
        joystickHorizontal = Joystick.Instance.Horizontal;
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (joystickHorizontal != 0) move = joystickHorizontal;
        else if (horizontalAxis != 0) move = horizontalAxis;
        else move = 0;

        m_HorizontalMove = move * m_RunSpeed;
        //Play animation walk
        PlayerAnimation.Instance.SantinoRun(Mathf.Abs(move));

        if (Mathf.Abs(move) > 0 && currentlevel == savedlevel)
        {
            PlayerPrefasManager.Instance.PositionX = gameObject.transform.position.x;
            PlayerPrefasManager.Instance.PositionY = gameObject.transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.Space)) jump = true;

        if (jump) PlayerAnimation.Instance.SantinoJump(jump);
    }

    private void FixedUpdate()
    {
        m_PlayerController.Move(m_HorizontalMove * Time.fixedDeltaTime, jump);
    }

    public void OnLand()
    {   
        jump = false;
        PlayerAnimation.Instance.SantinoJump(jump);
        movementDust.JumpVFX();
    
    }
}
