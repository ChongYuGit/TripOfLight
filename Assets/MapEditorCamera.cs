using UnityEngine;

public class MapEditorCamera : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D rig2D;
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rig2D.velocity = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * Speed;
    }
}
