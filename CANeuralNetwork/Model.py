import os
import numpy as np
import matplotlib.pyplot as plt
import tensorflow as tf
#import tensorflow_datasets as tfds
keras = tf.keras

image_size = 160
def format(image, label):
    image = tf.cast(image, tf.float32)
    image = (image/127.5) - 1
    image = tf.image.resize(image, (image_size, image_size))
    return image,label

path_to_model_h5 = r"C:\Users\Andrian\Desktop\Projects\CatsVsDogs\ClassificatonAplication\CANeuralNetwork\Model\cats_vs_dogs.h5";
new_model = keras.models.load_model(path_to_model_h5);



