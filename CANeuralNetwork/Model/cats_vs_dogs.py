import os
import numpy as np
import matplotlib.pyplot as plt
import tensorflow as tf
import tensorflow_datasets as tfds
keras = tf.keras

image_size = 160
def format(image, label):
    image = tf.cast(image, tf.float32)
    image = (image/127.5) - 1
    image = tf.image.resize(image, (image_size, image_size))
    return image,label


(raw_train, raw_validation, raw_test), metadata = tfds.load('cats_vs_dogs',split=["train[:80%]","train[80%:90%]","train[90%:]"],with_info = True,as_supervised=True)
train = raw_train.map(format)
validation = raw_validation.map(format)
test = raw_test.map(format)

train_batches = train.shuffle(990).batch(32)
validation_batches = validation.batch(990)
test_batches = test.batch(990)

image_shape = (160,160,3)
MobileNetV2 = tf.keras.applications.MobileNetV2(input_shape = (160,160,3), include_top = False, weights="imagenet")
MobileNetV2.trainable = False

model = tf.keras.Sequential([
MobileNetV2,
tf.keras.layers.GlobalAveragePooling2D(),
keras.layers.Dense(1)
])
model.compile(optimizer=tf.keras.optimizers.RMSprop(lr=0.001),loss=tf.keras.losses.BinaryCrossentropy(from_logits=True),metrics=['accuracy'])

model_trained = model.fit(train_batches,epochs=2,validation_data=validation_batches)
model.save("cats_vs_dogs.h5")
print(model_trained.history['accuracy'])




