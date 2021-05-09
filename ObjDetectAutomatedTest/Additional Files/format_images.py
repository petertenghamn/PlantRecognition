import os

from os.path import join

# script dir path
dirPath = os.path.dirname(__file__)
# input directories to generate new image files from
trainPath = join(dirPath, 'train')
testPath = join(dirPath, 'test')

# Output directories to put new images files into
basicPath = join(dirPath, 'basic')
formattedOutputPathTrain = join(basicPath, 'train')
if not os.path.exists(formattedOutputPathTrain):
    os.makedirs(formattedOutputPathTrain)
formattedOutputPathTest = join(basicPath, 'test')
if not os.path.exists(formattedOutputPathTest):
    os.makedirs(formattedOutputPathTest)

# get the names of all subdirectories
subFolders = [name for name in os.listdir(trainPath)]

# Get the name of all the images within the sub folders...
for folder in subFolders:
    folderPath = join(trainPath, folder)
    print(folderPath)
    n = 0
    for img in os.scandir(folderPath):
        n += 1
        # Rename all the images and move them to the new output folders
        filename = folder + '-{:06}.jpg'
        os.rename(img.path, join(formattedOutputPathTrain, filename).format(n))
        # write to labels the training images
        labelFile = open(join(basicPath, 'labels.csv'), 'a')
        labelFile.write(filename.format(n) + ',' + folder + "\n")

# get the names of all subdirectories
subFolders = [name for name in os.listdir(testPath)]

# Get the name of all the images within the sub folders...
for folder in subFolders:
    folderPath = join(testPath, folder)
    print(folderPath)
    n = 0
    for img in os.scandir(folderPath):
        n += 1
        # Rename all the images and move them to the new output folders
        filename = folder + '-{:06}.jpg'
        os.rename(img.path, join(formattedOutputPathTest, filename).format(n))
