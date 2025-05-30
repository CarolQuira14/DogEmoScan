using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Sentis;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngineInternal;
using TMPro;

public class ONNXManager : MonoBehaviour
{
    public TMP_Text resultadoTexto; // Para mostrar las etiquetas de clasificación
    [Header("Modelo y entrada")]
    [SerializeField] private ModelAsset modelAsset; // Asignar el modelo ONNX desde el inspector
    public EscogerImagen scriptEscogerImagen;
    [SerializeField] private Texture2D inputTexture; // Textura para almacenar la imagen seleccionada

    [Header("Resultados")]
    public string[] labels; // Etiquetas para las clases    

    [Header("UI")]
    public GameObject panel;
    public TextMeshProUGUI descriptionLabel;

    private Model runtimeModel;
    private Worker worker;
    public float[] labelProbabilities; // Resultados de clasificación
    public float[] results;

    public void ProcesarImagen()
    {
        if (inputTexture == null)
        {
            inputTexture = scriptEscogerImagen.imageTexture; // Obtener la textura de la imagen seleccionada
        }
        else
        {
            Debug.LogError("No se ha asignado una textura de entrada. Asegúrate de seleccionar una imagen antes de ejecutar el modelo.");
        }

        // Cargar y compilar el modelo ONNX
        runtimeModel = ModelLoader.Load(modelAsset);
        worker = new Worker(runtimeModel, BackendType.GPUCompute);

        // Convertir la imagen cargada a tensor
        var inputTensor = TextureConverter.ToTensor(inputTexture, width: 224, height: 224, channels: 3);
        Debug.Log("Tensor de entrada creado con forma: " + inputTensor.shape);

        // Ejecutar el modelo
        worker.Schedule(inputTensor);

        // Obtener la salida
        Tensor<float> outputTensor = worker.PeekOutput() as Tensor<float>;
        Debug.Log("Tensor de salida obtenido con forma: " + outputTensor.shape);
        results = outputTensor.DownloadToArray();


        int maxIndex = Array.IndexOf(results, results.Max());
        string predictedLabel = labels[maxIndex];

        resultadoTexto.text = predictedLabel;
        Debug.Log($"Etiqueta predicha: {predictedLabel}");


        inputTensor.Dispose(); // Liberar memoria del tensor de entrada
        outputTensor.Dispose(); // Liberar memoria del tensor de salida

        ShowEmotion(predictedLabel); // Mostrar la emoción en la UI

    }

    void OnDisable()
    {
        worker?.Dispose();
    }
    
    public void ShowEmotion(String predictedEmotion)
    {
        switch (predictedEmotion)
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
                resultadoTexto.text = "Emoción no reconocida";
                break;
        }
    }
}
