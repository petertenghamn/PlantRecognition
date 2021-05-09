# Place this within the training folder that you wish to create the label file for
# Before running this code

import os

# script dir path (make sure to overwrite the path if using this)
dirPath = "D:\\Program Files (x86)\\Github\\Temp holder"
newFolder = "\\inverted"
try:
    os.mkdir("D:\\Program Files (x86)\\Github\\Temp holder\\inverted")
except OSError:
    print("Creation of directory failed")

# Loop through all the images within the same folder, to create labels file
labelFile = open(os.path.join(dirPath, 'labels.csv'), 'a')
for root, dirs, files in os.walk(dirPath):
    for filename in files:
        if filename != "labels.csv":
            if filename != "label_maker_v02.py":
                # Rename all the images and move them to the new output folders
                img = dirPath + "\\" + filename
                os.rename(img, os.path.join(dirPath + "\\inverted", ("inverted-grey_" + filename)))
                # write to labels the training images
                c = filename.split("-")
                labelFile.write("inverted-grey_" + filename + ',' + c[0] + "\n")
