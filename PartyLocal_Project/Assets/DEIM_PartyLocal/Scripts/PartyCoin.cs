using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PartyCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        LocalPartyPlayer player = other.GetComponent<LocalPartyPlayer>();
        if (player == null || !PartyRoundManager.Instance.RoundRunning) return;

        PartyRoundManager.Instance.AddPoint(player.playerIndex);
        Reposition();
    }

    private void Reposition()
    {
        transform.position = new Vector3(
            Random.Range(-7f, 7f),
            Random.Range(-4f, 4f),
            0f
        );
    }
}
