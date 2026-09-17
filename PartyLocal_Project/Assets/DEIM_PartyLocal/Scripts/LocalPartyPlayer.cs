using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class LocalPartyPlayer : MonoBehaviour
{
    [Range(0, 3)] public int playerIndex;
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        PartyRoundManager.Instance.RegisterPlayer(this);
    }

    private void Update()
    {
        input = ReadInput(playerIndex);
    }

    private void FixedUpdate()
    {
        if (!PartyRoundManager.Instance.RoundRunning)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = input.normalized * speed;
    }

    private Vector2 ReadInput(int index)
    {
        float x = 0f;
        float y = 0f;

        if (index == 0)
        {
            if (Input.GetKey(KeyCode.A)) x--;
            if (Input.GetKey(KeyCode.D)) x++;
            if (Input.GetKey(KeyCode.S)) y--;
            if (Input.GetKey(KeyCode.W)) y++;
        }
        else if (index == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) x--;
            if (Input.GetKey(KeyCode.RightArrow)) x++;
            if (Input.GetKey(KeyCode.DownArrow)) y--;
            if (Input.GetKey(KeyCode.UpArrow)) y++;
        }
        else if (index == 2)
        {
            if (Input.GetKey(KeyCode.J)) x--;
            if (Input.GetKey(KeyCode.L)) x++;
            if (Input.GetKey(KeyCode.K)) y--;
            if (Input.GetKey(KeyCode.I)) y++;
        }
        else
        {
            if (Input.GetKey(KeyCode.Keypad4)) x--;
            if (Input.GetKey(KeyCode.Keypad6)) x++;
            if (Input.GetKey(KeyCode.Keypad2)) y--;
            if (Input.GetKey(KeyCode.Keypad8)) y++;
        }

        return new Vector2(x, y);
    }
}
