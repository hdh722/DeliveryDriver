using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
public class Drift : MonoBehaviour
{
    [SerializeField] float accleration = 20f;   //전진후진 가속도
    [SerializeField] float steering = 3f;       //조향속도
    [SerializeField] float maxSpeed = 10f;      //최대속도제한
    [SerializeField] float driftFactor = 0.95f;      //낮을수록더미끄러짐
    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;
    [SerializeField] TrailRenderer leftTrail;
    [SerializeField] TrailRenderer rightTrail;
    [SerializeField] float slowAccelerationRatio = 0.5f;
    [SerializeField] float boostAccelerationRatid = 1.5f;
    float defaultAcceleration;
    float slowAcceleration;
    float boostAcceleration;
    Rigidbody2D rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = rb.GetComponent<AudioSource>();

        defaultAcceleration = accleration;
        slowAcceleration = accleration * slowAccelerationRatio;
        boostAcceleration = accleration * boostAccelerationRatid;
    }
    void FixedUpdate()
    {
        float speed = Vector2.Dot(rb.linearVelocity, transform.up);
        if (speed < maxSpeed)
        {
            rb.AddForce(transform.up * Input.GetAxis("Vertical") * accleration);
        }
        float turnAmount = Input.GetAxis("Horizontal") * steering * Mathf.Clamp(speed / maxSpeed, 0.4f, 1f);
        rb.MoveRotation(rb.rotation + -turnAmount);
        
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 sideVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);
        rb.linearVelocity = forwardVelocity + (sideVelocity * driftFactor);
    }
    private void Update()
    {
        float sidewayVelocity = Vector2.Dot(rb.linearVelocity, transform.right);

        bool isDrifting = rb.linearVelocity.magnitude > 2f && Mathf.Abs(sidewayVelocity) > 1f;
        if (isDrifting)
        {
            if (!audioSource.isPlaying) audioSource.Play();
            if (!smokeLeft.isPlaying) smokeLeft.Play();
            if (!smokeRight.isPlaying) smokeRight.Play();
        }else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            if (smokeLeft.isPlaying) smokeLeft.Stop();
            if (smokeRight.isPlaying) smokeRight.Stop();
        }
        leftTrail.emitting = isDrifting;
        rightTrail.emitting = isDrifting;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            accleration = boostAcceleration;
            Debug.Log("Booooooost");
            Invoke(nameof(ResetAcceleration),5f);
        }
    }
    void ResetAcceleration()
    {
        accleration = defaultAcceleration;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        accleration = slowAcceleration;
        Invoke(nameof(ResetAcceleration),3f);
    }
}
