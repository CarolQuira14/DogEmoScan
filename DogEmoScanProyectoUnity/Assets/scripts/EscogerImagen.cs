using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class EscogerImagen : MonoBehaviour
{
    public Button pickImageButton;
    public Texture2D imageTexture; //Textura para almacenar la imagen seleccionada
    public ONNXManager onnxManager; //Referencia al ONNXManager
    public GANManager ganManager; //Referencia al GANManager

    private void Start()
    {
        pickImageButton.onClick.AddListener(PickImageFromGallery);
    }

    public void PickImageFromGallery()
    {
        NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // Cargar la imagen como textura
                imageTexture = NativeGallery.LoadImageAtPath(path, maxSize: 1024);
                if (imageTexture == null)
                {
                    Debug.LogError("No se pudo cargar la imagen.");
                    return;
                }

                // Ejecutar el modelo después de cargar la imagen
                if (onnxManager != null)
                {
                    onnxManager.ProcesarImagen(); // <<< Aquí se llama al modelo CNN
                }
                else
                {
                    Debug.LogError("No se ha asignado ONNXManager en EscogerImagen.");
                }
                
                if (ganManager != null)
                {
                    ganManager.ProcesarImagen(); // <<< Aquí se llama al modelo GAN
                }
                else
                {
                    Debug.LogError("No se ha asignado ONNXManager en EscogerImagen.");
                }

                
            }
        }, "Selecciona una imagen", "image/*");

    }
}
