using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalendarManager : MonoBehaviour
{
    public Color currentDayColor; // Color del día actual
    public GameObject dayButtonPrefab; // Prefab del botón del día
    public Transform daysGridParent; // Donde se instanciarán los botones
    public TextMeshProUGUI monthLabel; // Etiqueta del mes actual

    private DateTime currentDate;

    private Dictionary<string, Sprite> emotionToSprite = new();
    private Dictionary<int, string> emotionByDay = new();

    public List<emotionSprites> emotionSpritesList;

    [SerializeField] private TMP_Text emotionText;


    private void Start()
    {
        currentDate = DateTime.Now;
        GenerateCalendar(currentDate);
    }

    public void GenerateCalendar(DateTime date)
    {
        emotionToSprite.Clear();
        foreach (var item in emotionSpritesList)
        {
            emotionToSprite[item.emotionName.ToLower()] = item.icon;
        }


        monthLabel.text = date.ToString("MMMM yyyy").ToUpper();

        // Limpiar botones anteriores
        foreach (Transform child in daysGridParent)
        {
            Destroy(child.gameObject);
        }

        DateTime firstDay = new DateTime(date.Year, date.Month, 1);
        int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        int startDayOfWeek = (int)firstDay.DayOfWeek;

        // Ajustar para que el domingo sea 0
        //startDayOfWeek = startDayOfWeek == 0 ? 6 : startDayOfWeek - 1;

        // Días en blanco antes del primero del mes
        for (int i = 0; i < startDayOfWeek; i++)
        {
            Instantiate(dayButtonPrefab, daysGridParent);
        }

        // Días del mes
        for (int day = 1; day <= daysInMonth; day++)
        {
            GameObject btnObj = Instantiate(dayButtonPrefab, daysGridParent);
            TextMeshProUGUI dayText = btnObj.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            dayText.text = day.ToString();

            Image iconImage = btnObj.transform.Find("EmotionIcon").GetComponent<Image>();

            if (emotionByDay.ContainsKey(day))
            {
                string emotion = emotionByDay[day];
                if (emotionToSprite.ContainsKey(emotion))
                {
                    iconImage.sprite = emotionToSprite[emotion];
                    iconImage.gameObject.SetActive(true);
                }
                else iconImage.gameObject.SetActive(false);
            }
            else iconImage.gameObject.SetActive(false);

            // 👉 Pintar día actual
            bool isToday = (day == DateTime.Now.Day &&
                            date.Month == DateTime.Now.Month &&
                            date.Year == DateTime.Now.Year);

            if (isToday)
            {
                Image bgImage = btnObj.GetComponent<Image>();
                if (bgImage != null)
                {
                    bgImage.color = currentDayColor;
                }
            }
        }
    }

    // Simulación: cada día con emoción
    public void RegisterEmotionForToday(string emotionName)
    {
        int today = DateTime.Now.Day;
        emotionByDay[today] = emotionName.ToLower();
        GenerateCalendar(DateTime.Now); // Actualiza el calendario con el ícono
    }


    public void NextMonth()
    {
        currentDate = currentDate.AddMonths(1);
        GenerateCalendar(currentDate);
    }

    public void PrevMonth()
    {
        currentDate = currentDate.AddMonths(-1);
        GenerateCalendar(currentDate);
    }
}

