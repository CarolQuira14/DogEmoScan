using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Sentis;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngineInternal;


public class GANManager : MonoBehaviour
{
    [Header("Modelo y entrada")]
    [SerializeField] private ModelAsset modelAsset; // Asignar el modelo ONNX desde el inspector
    public EscogerImagen scriptEscogerImagen;
    [SerializeField] private Texture2D inputTexture; // Textura para almacenar la imagen seleccionada

    [Header("Resultados")]
    public RawImage outputImageDisplay; // Para mostrar la imagen caricaturizada


    private Model runtimeModel;
    private Worker worker;
    // Start is called before the first frame update
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

        // Cargar y compilar el modelo GAN
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

        var outputArray = outputTensor.DownloadToArray(); //Convertir el tensor de salida a un array

        //2. Salida de imagen (caricatura generada)
        int width = 512; // Ajusta el tamaño según tu modelo
        int height = 512; // Ajusta el tamaño según tu modelo
        RenderTexture renderTex = new RenderTexture(width, height, 3, RenderTextureFormat.ARGB32);
        renderTex.enableRandomWrite = true;
        renderTex.Create(); // Crear un RenderTexture para almacenar la imagen generada

        // Normalizar de [-1, 1] a [0, 1]
        for (int i = 0; i < outputArray.Length; i++)
        {
            outputArray[i] = (outputArray[i] + 1f) / 2f;
        }

        var normalizedTensor = new Tensor<float>(outputTensor.shape, outputArray); //Crear un nuevo tensor normalizado

        // Calcular relación de aspecto original
        float aspectRatio = (float)inputTexture.width / inputTexture.height;

        // Ajustar dimensiones del RenderTexture manteniendo proporción (basado en ancho fijo)
        int outputWidth = 512;
        int outputHeight = Mathf.RoundToInt(outputWidth / aspectRatio);

        renderTex = new RenderTexture(outputWidth, outputHeight, 0, RenderTextureFormat.ARGB32);
        renderTex.enableRandomWrite = true;
        renderTex.Create();

        // Renderizar el tensor normalizado en el RenderTexture
        TextureConverter.RenderToTexture(normalizedTensor, renderTex);

        // Asignar imagen al UI
        outputImageDisplay.texture = renderTex;

        // Ajustar proporción del RawImage con AspectRatioFitter
        AspectRatioFitter aspectFitter = outputImageDisplay.GetComponent<AspectRatioFitter>();
        if (aspectFitter != null)
        {
            aspectFitter.aspectRatio = aspectRatio;
        }

        // Liberar memoria
        inputTensor.Dispose();
        outputTensor.Dispose();
        normalizedTensor.Dispose();
    }


    void OnDisable()
    {
        worker?.Dispose();
    }

    
}
