# PlantRecognition Solution
 
The projects in this repository were done as part of a Bachelor Thesis at HKR in Sweden.
 
All of the projects were made using visual studio 2019.
These projects were made to test augmentation of images and their effect on accuracy and confidence in object detection models on plants.
Some of the projects are not complete or very basic as they were initial tests run by us to learn more about object detectors.

The solution contains 4 projects which we will go over now.

*In order to run the projects successfully make sure to do the following:
- Install the packages mentioned bellow for the individual project
- Only have one version of visual studio to run the program on. Microsoft Visual C++ 2015-2019 Redistributable (x64) - 14.22.27821
- Run the programs in Debug mode x64 or x86

## Microsoft ML with Tensorflow classifiers

### AgriculturalDetector Project (or ObjDetectV01)

Our initial project to run tensorflow classifier on some test images to see how everything works.

Should run internally using Tensorflow and can be testing using the images contained within the projects files.

### ObjDetectAutomatedTest Project

More extensive tester built from the previous project.
Rather then the user looking for an image to test the algorithm with, the program scans through the files and gives accuracy results.

The Data set used is from Harvard's public datasets. Found when searching for Harvard - flowers dataset.
It contains ~3500 images, 47 of which we used in the training of the model.
All images are reformatted to 416 x 416 pixels.
A duplicated set of the same images was used with the augmentation of greyscaling to test our thesis with.

## Yolo detectors

### AgriculturalDetectV02 Project

YoloV2 project which was made to try to expand our project into individual identification of objects within an image.

This uses pretrained yoloV2 model that is downloaded when clicked on detect button.

*** MUST UNCOMMENT CODE BIT FOR DOWNLOAD TO OCCUR *****

Requirements to not get  missing packages:

use reinstall command in package console

Only open plant recognition v2 solution

### ObjDetectV03 Project

YoloV3 project with the same intent as previous, testing the augmentations on indentifying multiple objects within an image.
This project was left at a base level however, due to time constaints the project only made it as far as to test the yolo algorithm without having time to train it using the large datasets.
