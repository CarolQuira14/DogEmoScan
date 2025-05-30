# DogEmoScan Sistema Interactivo de Clasificación Emocional y Estilización Artística de Imágenes Caninas Usando Redes Neuronales

DogEmoScan es una aplicación interactiva que permite a los usuarios identificar las emociones de sus perros a partir de una imagen y estilizarla artísticamente en formato óleo. Combinando el poder del aprendizaje profundo con una experiencia visual atractiva, DogEmoScan promueve la empatía y el bienestar animal a través de la inteligencia artificial.

Este repositorio contiene:

🧩 Proyecto en Unity
Cuatro carpetas de proyecto DogEmoScan con interfaz gráfica para abrir con Unity. Incluye:

Carga de imagen.

Clasificación emocional.

Estilización artística.

Visualización en un calendario interactivo.

📓 Notebooks en Colab

Entrenamiento_resnet18.ipynb: Entrenamiento del modelo ResNet-18 para clasificación de emociones.
ModeloEmociones_faceGan: Script para inferencia de emociones y transformación de imágenes en estilo óleo, sin interfaz gráfica.

🎥 Video demostrativo
Video del resultado logrado desde el Player de Unity.


Clasificación de Emociones - ResNet-18
Implementado en PyTorch.
Estilización Artística - FaceGAN
Modelo generativo preentrenado que transforma imágenes faciales en retratos con estilo óleo.

Adaptado para imágenes caninas como parte de la experiencia emocional-visual.

Implementado también en formato ONNX.

Se descartaron alternativas como CartoonGAN y StyleGAN2 por requerimientos computacionales y tiempo de entrenamiento.
Entrenado con un dataset personalizado de imágenes caninas etiquetadas en 4 clases emocionales: Feliz, Enojado, Triste y Neutro.

Migrado a formato ONNX para integración en Unity a través de Unity Sentis.

Proceso de inferencia en Unity mediante tensores que devuelven la clase con mayor probabilidad.
Instalación y Uso
Requisitos
Unity 2022.3+ con Sentis instalado.

Python 3.8+

Bibliotecas: torch, torchvision, onnx, opencv-python, etc. (ver notebooks para más detalles)

Autores
Ana E. Pardo-Quiñonez — ana.pardo@uao.edu.co

Carol N. Quira-Campo — carol.quira@uao.edu.co

Joan S. Salcedo-Obando — joan.salcedo@uao.edu.co
Contribuciones
¿Tienes ideas para mejorar DogEmoScan?
¡Eres bienvenido a contribuir!
