using UnityEngine;
using UnityEngine.SceneManagement;

public class PartyRoundManager : MonoBehaviour
{
    public static PartyRoundManager Instance { get; private set; }

    public float roundDuration = 60f;
    public bool RoundRunning { get; private set; }

    private readonly int[] scores = new int[4];
    private readonly LocalPartyPlayer[] players = new LocalPartyPlayer[4];
    private float timeLeft;
    private bool started;

    private void Awake()
    {
        Instance = this;
        timeLeft = roundDuration;
    }

    public void RegisterPlayer(LocalPartyPlayer player)
    {
        if (player.playerIndex >= 0 && player.playerIndex < players.Length)
            players[player.playerIndex] = player;
    }

    public void AddPoint(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < scores.Length)
            scores[playerIndex]++;
    }

    private void Update()
    {
        if (!started && Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            RoundRunning = true;
        }

        if (RoundRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                RoundRunning = false;
            }
        }

        if (!RoundRunning && started && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private int WinnerIndex()
    {
        int winner = 0;
        for (int i = 1; i < scores.Length; i++)
            if (scores[i] > scores[winner]) winner = i;
        return winner;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 520, 110), "PARTY LOCAL — RECOGE MONEDAS");

        GUI.Label(new Rect(25, 40, 470, 25),
            $"P1: {scores[0]}   P2: {scores[1]}   P3: {scores[2]}   P4: {scores[3]}");

        GUI.Label(new Rect(25, 65, 470, 25),
            started ? $"Tiempo: {Mathf.CeilToInt(timeLeft)} s" : "Pulsa ESPACIO para empezar");

        GUI.Label(new Rect(25, 90, 480, 25),
            "P1 WASD | P2 Flechas | P3 IJKL | P4 teclado numérico");

        if (started && !RoundRunning)
        {
            GUI.Box(new Rect(Screen.width / 2 - 170, Screen.height / 2 - 60, 340, 120),
                "FIN DE LA RONDA");
            GUI.Label(new Rect(Screen.width / 2 - 110, Screen.height / 2 - 20, 240, 25),
                $"Jugador {WinnerIndex() + 1} tiene más puntos.");
            GUI.Label(new Rect(Screen.width / 2 - 110, Screen.height / 2 + 10, 240, 25),
                "Pulsa R para repetir.");
        }
    }
}
