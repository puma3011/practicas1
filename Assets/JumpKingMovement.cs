using UnityEngine;

public class JumpKingMovement : MonoBehaviour
{
    public float maxChargeTime = 1.5f;
    public float maxJumpForce = 20f;
    public Vector2 baseJumpDirection = new Vector2(1, 2); // dirección inclinada base
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f); // más ancho que alto
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public bool IsCharging => isCharging;
    public float ChargePercent => Mathf.Clamp01(chargeTime / maxChargeTime);
    public bool EstaEnSuelo => isGrounded;



    private Rigidbody2D rb;
    private bool isCharging = false;
    private float chargeTime = 0f;
    private bool isGrounded = false;

    private int inputDirection = 0; // -1 = izquierda, 1 = derecha, 0 = sin dirección

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        groundCheck.position = transform.position + new Vector3(0, -col.bounds.extents.y - 0.1f, 0);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        if (isGrounded)
        {
            // Detectar dirección solo al iniciar o durante la carga del salto
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isCharging = true;
                chargeTime = 0f;

                // Detectar si se está presionando una flecha
                if (Input.GetKey(KeyCode.LeftArrow))
                    inputDirection = -1;
                else if (Input.GetKey(KeyCode.RightArrow))
                    inputDirection = 1;
                else
                    inputDirection = 0; // salto vertical
            }

            if (Input.GetKey(KeyCode.Space) && isCharging)
            {
                chargeTime += Time.deltaTime;
                chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);
            }

            if (Input.GetKeyUp(KeyCode.Space) && isCharging)
            {
                isCharging = false;
                float chargePercent = chargeTime / maxChargeTime;

                Vector2 dir;
                if (inputDirection == 0)
                {
                    dir = Vector2.up; // salto recto hacia arriba
                }
                else
                {
                    // salto inclinado izquierda/derecha
                    dir = new Vector2(inputDirection * baseJumpDirection.x, baseJumpDirection.y).normalized;
                }

                Vector2 force = dir * (chargePercent * maxJumpForce);
                rb.linearVelocity = force;
            }
        }
    }
    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        }
    }
}
