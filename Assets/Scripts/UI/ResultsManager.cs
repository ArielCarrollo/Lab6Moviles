using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoretxt;
    [SerializeField] TextMeshProUGUI currentscoretxt;
    [SerializeField] Score_LifeDataSO finalscore;
    [SerializeField] private PaletteSO paletteColor;
    private int highscore;

    private void Start()
    {
        finalscore.CheckAndSetHighScore(); // Actualiza antes de mostrar

        finalscoretxt.color = paletteColor.color;
        NotificationSimple.Instance.SendNotification("¡Rodan terminada!", "Puntaje actual: " + finalscore.currentScore, 0);
        currentscoretxt.text = "Current Score: " + finalscore.currentScore;
        finalscoretxt.text = "High Score: " + finalscore.highScore;
    }
}
