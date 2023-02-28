using UnityEngine;

public class PlayerManager : View
{
    //public VariableJoystick variableJoystick;

    float h;
    float v;
    public float speed = 6;
    public float turnSpeed = 15;
    public Transform camTransform;
    Vector3 movement;
    Vector3 camForward;

    GameModel gm;

    public override string Name => Consts.V_PlayerManager;

    public override void HandleEvent(string name, object data)
    {
    }

    private void Awake()
    {
        gm = GetModel<GameModel>();

        camTransform = Camera.main.transform;
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (gm.IsPlay && !gm.IsPause)
        {
            //Move();
            //JoystickMove();
        }
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        transform.Translate(camTransform.right * h * speed * Time.deltaTime + camForward * v * speed * Time.deltaTime, Space.World);
        if (h != 0 || v != 0)
        {
            Rotating(h, v);
        }
    }

    // private void JoystickMove()
    // {
    //     h = variableJoystick.Horizontal;
    //     v = variableJoystick.Vertical;
    //
    //     transform.Translate(camTransform.right * h * speed * Time.deltaTime + camForward * v * speed * Time.deltaTime, Space.World);
    //     if (h != 0 || v != 0)
    //     {
    //         Rotating(h, v);
    //     }
    // }

    private void Rotating(float hh, float vv)
    {
        camForward = Vector3.Cross(camTransform.right, Vector3.up);

        Vector3 targetDir = camTransform.right * hh + camForward * vv;

        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag.dead) //游戏结束
        {
            //声音
            Sound.Instance.PlayEffect("Se_UI_End");
            //other.gameObject.SendMessage("HitPlayer", transform.position);
            Destroy(other.gameObject);

            //sendEvent 游戏结束
            SendEvent(Consts.E_EndGame);
        }
    }
}