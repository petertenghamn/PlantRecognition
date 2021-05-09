# Place this within the training folder that you wish to create the label file for
# Before running this code

import os

# script dir path
dirPath = os.path.dirname(__file__)

# Loop through all the images within the same folder, to create labels file
labelFile = open(os.path.join(dirPath, 'labels.csv'), 'a')
for root, dirs, files in os.walk(dirPath):
    for filename in files:
        c = filename.split("-")
        # write to labels the training images
        labelFile.write(filename + ',' + c[0] + "\n")
