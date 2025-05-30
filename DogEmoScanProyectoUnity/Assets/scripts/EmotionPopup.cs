using UnityEngine;
using TMPro;

public class EmotionPopup : MonoBehaviour
{
    public static EmotionPopup Instance;

    public GameObject panel;
    public TextMeshProUGUI emotionLabel;
    public TextMeshProUGUI descriptionLabel;

    private void Awake()
    {
        Instance = this;
        //panel.SetActive(false);
    }

    public void ShowEmotion(TMP_Text emotion)
    {
        panel.SetActive(true);

        // Puedes personalizar los textos por emoción aquí
        switch (emotion.text)
        {
            case "Alegre":
                descriptionLabel.text = "El perro muestra una expresión feliz.";
                break;
            case "Triste":
                descriptionLabel.text = "El perro parece estar desanimado o apagado.";
                break;
            case "Enojado":
                descriptionLabel.text = "El perro muestra signos de incomodidad o estrés.";
                break;
            case "Neutro":
                descriptionLabel.text = "El perro tiene una expresión neutral, sin emociones evidentes.";
                break;
            default:
                descriptionLabel.text = "Aun no ha seleccionado una imagen para identificar la emoción.";
                emotionLabel.text = "Emoción no reconocida";
                break;
        }
    }

    public void ClosePopup()
    {
        panel.SetActive(false);
    }
}
