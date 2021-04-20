using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public KeyCode shoot;

    private Rigidbody rig;

    public float speed = 662f;
    public float jumpHeight = 8f;

    public bool inAir;

    public bool lookingRight;

    public GameObject bomb;

    public float coolDown;

    private float timeStamp;

    public float bombSpeed;
    public float bombHeight;

    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        movementHandler();
        shootingHandler();
    }

    private void shootingHandler()
    {
        if (Input.GetKey(shoot))
        {
            if (timeStamp <= Time.time)
            {
                Vector3 pos = transform.position;

                pos.y += 1f;

                GameObject bombGm = Instantiate(bomb, pos, Quaternion.identity) as GameObject;


                if (lookingRight)
                {
                    bombGm.GetComponent<Rigidbody>().AddForce(transform.up * bombHeight);
                    bombGm.GetComponent<Rigidbody>().AddForce(transform.right * bombSpeed);
                    bombGm.GetComponent<Rigidbody>().mass = 69f;
                    print(bomb.name);
                }
                else
                {
                    bombGm.GetComponent<Rigidbody>().AddForce(transform.up * bombHeight);
                    bombGm.GetComponent<Rigidbody>().AddForce(transform.right * bombSpeed);
                }

                timeStamp = Time.time + coolDown;
            }

        }
    }

    private void movementHandler()
    {
        if (Input.GetKey(leftKey))
        {
            rig.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Force);
            if (transform.rotation.y == 0)
            {
                transform.RotateAround(transform.position, transform.up, 180f);
                lookingRight = false;
            }
        }
        if (Input.GetKey(rightKey))
        {
            rig.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Force);
            if (transform.rotation.y != 0)
            {
                transform.RotateAround(transform.position, transform.up, 180f);
                lookingRight = true;
            }
        }
        if (Input.GetKeyDown(jumpKey))
        {
            if (inAir == false)
            {
                inAir = true;
                rig.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            inAir = false;
        }
    }
}
