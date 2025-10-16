using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float GravityScaleOriginal { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GravityScaleOriginal = rb.gravityScale;
    }
    public void AddImpulseUP(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }
    public float GetVelocityY()
    {
        return rb.velocity.y;
    }

    public void MaxVelocityControl(float maxVelocityUP)
    {
        //상승때만 속도 제한
        if (rb.velocity.y > maxVelocityUP)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Sign(rb.velocity.y) * maxVelocityUP);
        }
    }
    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }
    public void SetGravityScale(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }
    public void SetGravityScaleToOriginal()
    {
        rb.gravityScale = GravityScaleOriginal;
    }
    public void SetBodyTypeToKenematic()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    public void SetBodyTypeToDynamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void DontRotate()
    {
        rb.freezeRotation = true;
    }
    public void DoRotate()
    {
        rb.freezeRotation = false;
    }
}
