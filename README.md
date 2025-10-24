# 🐶 DogEmoScan  
### Sistema Interactivo de Clasificación Emocional y Estilización Artística de Imágenes Caninas con IA (Unity + Sentis)

**DogEmoScan** es una aplicación interactiva que combina **visión por computadora**, **redes neuronales** y **procesamiento de imágenes** para analizar emociones de perros a partir de una fotografía y generar una **estilización artística tipo óleo** mediante un modelo generativo.

Este proyecto integra **modelos de Deep Learning en Unity** usando **Unity Sentis**, logrando una experiencia accesible y visualmente atractiva sin depender de servidores externos.

---

## 🎯 Objetivo del proyecto

- Identificar emociones caninas a partir de una imagen.
- Interpretar el resultado mediante etiquetas emocionales: **Feliz, Enojado, Triste o Neutro**.
- Aplicar un estilo artístico tipo **óleo** usando una red generativa basada en FaceGAN.
- Ofrecer una experiencia interactiva educativa sobre emociones animales.

---

## 🧩 Contenido del Repositorio

### ✅ Proyecto en Unity
Incluye la estructura completa del proyecto listo para ser abierto en **Unity 2022.3+** con **Unity Sentis**, con las siguientes funcionalidades:

| Módulo | Descripción |
|--------|-------------|
| 📷 Carga de imagen | El usuario selecciona una imagen desde su dispositivo |
| 🤖 Clasificación emocional | Uso de modelo ResNet-18 exportado a ONNX |
| 🎨 Estilización artística | Transformación tipo pintura al óleo |
| 📅 Vista calendario | Galería interactiva con resultados |

---

### 📓 Notebooks (Google Colab)

| Notebook | Descripción |
|----------|-------------|
| `Entrenamiento_resnet18.ipynb` | Entrenamiento para clasificación de emociones con ResNet-18 (PyTorch) |
| `ModeloEmociones_faceGan.ipynb` | Inferencia + estilo artístico sin interfaz gráfica |

---

## 🧠 Inteligencia Artificial Utilizada

### 🔹 Clasificación Emocional (ResNet-18)
- Framework: PyTorch → Exportado a **ONNX para Sentis**
- Dataset: Imágenes caninas clasificadas en 4 emociones
- Salida: Softmax con la probabilidad de cada emoción

### 🔹 Estilización Artística (FaceGAN Adaptado)
- Generación de estilo artístico tipo óleo
- Adaptado para rostros de perros
- Optimizado para inferencia en Unity

---

## ⚙️ Requisitos

| Componente | Requisito |
|-------------|-----------|
| Unity | Versión **2022.3+** |
| Dependencia IA | **Unity Sentis** |
| Python (opcional) | **3.8+** (para reentrenar modelos) |
| Bibliotecas IA | torch, torchvision, onnx, opencv-python |

---

## 🚀 Instalación y Uso

1. Clona este repositorio
   ````bash
   git clone https://github.com/CarolQuira14/DogEmoScan.git
2. Abre el proyecto en Unity (2022.3+).
3. Instala **Sentis** desde Unity Package Manager.
4. Ejecuta la escena **MainScene**.
5. Carga una imagen y observa la clasificación + estilización.

---
## 👩‍💻 Rol en el Proyecto

Este proyecto fue desarrollado de manera colaborativa. Mis responsabilidades principales fueron:

✅ Integración del modelo ONNX en Unity usando Sentis  
✅ Programación de interacción en Unity (C#)  
✅ Optimización del pipeline de inferencia para ejecución en tiempo real  
✅ Diseño técnico general del sistema  

---

## 👥 Autores

| Nombre                           | Rol                                    | GitHub                                                             |
| -------------------------------- | -------------------------------------- | ------------------------------------------------------------------ |
| **Ana Elizabeth Pardo Quiñonez** | Diseño visual y dataset                | [https://github.com/aelizaa](https://github.com/aelizaa)           |
| **Joan Sebastian Salcedo**       | UI/UX y estructura Unity               | [https://github.com/joansalcedo1](https://github.com/joansalcedo1) |
| **Carol Natalia Quira Campo**    | Integración IA + Sentis · Programación | [https://github.com/CarolQuira14](https://github.com/CarolQuira14) |

---

## 📫 Contacto

**Carol Natalia Quira Campo**
Correo: carolquira14@gmail.com
GitHub: [https://github.com/CarolQuira14](https://github.com/CarolQuira14)

---
