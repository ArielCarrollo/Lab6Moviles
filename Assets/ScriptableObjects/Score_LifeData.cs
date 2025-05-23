using UnityEngine;

[CreateAssetMenu(fileName = "Score_LifeData", menuName = "ScriptableObjects/ScoreLifeData")]
public class Score_LifeDataSO : ScriptableObject
{
    public int currentScore;
    public int currentlife;
    public int highScore;
    public void ResetScore()
    {
        currentScore = 0;
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
    }

    public void RestLife(int amount)
    {
        currentlife -= amount;
    }

    public void CheckAndSetHighScore()
    {
        int puntuacionGuardada = PlayerPrefs.GetInt("PuntuacionMaxima", 0);

        if (currentScore > puntuacionGuardada)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("PuntuacionMaxima", currentScore);
            PlayerPrefs.Save(); // Muy importante guardar
            NotificationSimple.Instance.SendHighScoreNotification("�Superaste tu puntaje!", "Nuevo puntaje m�ximo: " + highScore, 0);
        }
        else
        {
            highScore = puntuacionGuardada;
        }
    }

}
