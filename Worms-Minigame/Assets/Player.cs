using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    private Rigidbody rig;

    public float speed = 662f;
    public float jumpHeight = 8f;

    public bool inAir;


    private void Start()
    {
        rig = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        movementHandler();
    }
    private void movementHandler()
    {
        if (Input.GetKey(leftKey))
        {
            rig.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Force);
        }
        if (Input.GetKey(rightKey))
        {
            rig.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Force);
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
