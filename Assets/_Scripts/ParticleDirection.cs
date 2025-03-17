using UnityEngine;

public class ParticleDirection : MonoBehaviour
{
    ParticleSystem ps;
    Rigidbody rb;
    GameObject child;
    Vector3 prvVel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        child = transform.Find("Sphere").gameObject;
        ps = child.GetComponent<ParticleSystem>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, prvVel, Color.yellow);
        Debug.DrawRay(transform.position, rb.linearVelocity, Color.magenta);
    }

    public void UpdatePreviousVelocity (Vector3 vel)
    {
        prvVel = new Vector3(vel.normalized.x, 0, vel.normalized.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (prvVel.x == )

        //Vector3 deltaC = collision.transform.position - transform.position;
        //Debug.Log($"Delta C{deltaC}");

        Vector3 curVel = new Vector3(rb.linearVelocity.normalized.x, 0, rb.linearVelocity.normalized.z);

        float theta = -1 * Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.right, curVel));
        //theta = Mathf.Rad2Deg * Mathf.Asin(curVel.z / curVel.magnitude);

        child.transform.rotation = Quaternion.identity;
        child.transform.Rotate(0, theta, 0);
    }
}
