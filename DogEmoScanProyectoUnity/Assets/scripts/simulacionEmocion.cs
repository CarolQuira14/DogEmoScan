using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simulacionEmocion : MonoBehaviour
{
    public CalendarManager calendarManager;

    public void SimularRegistroDeEmocion()
    {
        string[] emociones = { "feliz", "triste", "enojado", "neutro" };
        int rand = Random.Range(0, emociones.Length);
        string emocion = emociones[rand];

        calendarManager.RegisterEmotionForToday(emocion);
    }

        public void SimularFeliz()
    {
        calendarManager.RegisterEmotionForToday("feliz");
    }
}
