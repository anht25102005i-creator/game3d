using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float tocDoXe = 20f;
    [SerializeField] private float lucReXe = 80f;
    [SerializeField] private float lucPhanh = 100f;
    [SerializeField] private GameObject hieuUngPhanh;

    private float dauVaoDiChuyen;
    private float dauVaoRe;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // giúp xe khó lật
    }

    private void FixedUpdate()
    {
        dauVaoDiChuyen = Input.GetAxis("Vertical");
        dauVaoRe = Input.GetAxis("Horizontal");

        DiChuyenXe();
        ReXe();

        if (dauVaoDiChuyen > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            PhanhXe();
        }
    }

    public void DiChuyenXe()
    {
        rb.AddRelativeForce(Vector3.forward * dauVaoDiChuyen * tocDoXe);
        hieuUngPhanh.SetActive(false);
    }

    public void ReXe()
    {
        Quaternion re = Quaternion.Euler(0, dauVaoRe * lucReXe * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * re);
    }

    public void PhanhXe()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.AddRelativeForce(-Vector3.forward * lucPhanh);
            hieuUngPhanh.SetActive(true);
        }
    }
}
