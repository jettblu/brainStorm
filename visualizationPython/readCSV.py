import csv
from pathlib import Path
from tkinter import filedialog
import numpy as np
from visualization.chart import chartElectrode, chartEEG, chartTrainResponse, chartResponseAcrossElectrodes
import time

# set indices for parsing CSV
indexElectrodeNames = 3
indexBands = 20
indexEEGStd = 90
numElectrodes = 14
numBands = 70


class EEGData:
    def __init__(self):
        self.Values = []
        self.StdDeviationValues = []
        self.MovingAvgValues = []
        self.UpperBounds = []
        self.LowerBounds = []
        self.PeakPoints = []
        self.TrainingPoints = []


class RawEEG(EEGData):
    pass


class Theta(EEGData):
    pass


class Alpha(EEGData):
    pass


class BetaL(EEGData):
    pass


class BetaH(EEGData):
    pass


class Gamma(EEGData):
    pass


# from visuals import *
class Electrode:
    freqNamesOutput = []
    electrodeDict = dict()
    header = []
    timeBands = []
    timeEEG = []
    BandBoundMask = []
    RawEEGBoundMask = []
    Frequency = 128

    def __init__(self, name):
        self.Name = name
        self.RawEEG = []
        self.RawEEG = RawEEG()
        self.Theta = Theta()
        self.Alpha = Alpha()
        self.BetaL = BetaL()
        self.BetaH = BetaH()
        self.Gamma = Gamma()
        Electrode.electrodeDict[name] = self

    def __repr__(self):
        return self.Name


def getPaths():
    fileNames = []
    files = filedialog.askopenfilenames(title="Choose CSV(s)", filetypes=(("CSV Files", "*.csv"),))
    # directory for visualizations
    dirName = filedialog.askdirectory()
    for file in files:
        fileName = Path(file).stem
        fileNames.append(fileName)

    return files, fileNames, dirName


def createVisualizations():
    filePaths, fileNames, folderPath = getPaths()
    for i, path in enumerate(filePaths):
        print(f'Reading {fileNames[i]}...')
        start = time.time()
        readData(path)
        print(f'{round(time.time()-start, 2)} seconds to read {fileNames[i]}')
        currElectrode = Electrode.electrodeDict["F7"]
        chartResponseAcrossElectrodes(electrodeDict=Electrode.electrodeDict, bandName="Theta")
        chartElectrode(currElectrode)
        chartEEG(currElectrode, f"{currElectrode.Name} Signal vs. Time")
        chartTrainResponse(currElectrode)
    print('Process finished!')


def readData(filePath):
    name = Path(filePath).stem
    with open(filePath, newline='') as csvfile:
        dataReader = csv.reader(csvfile, delimiter=",")
        # create a list of category labels
        Electrode.header = [cat for cat in next(dataReader)]
        # instantiate electrodes
        for i, label in enumerate(Electrode.header):
            if isRawEEG(i):
                Electrode(label.strip())
            if isBand(i):
                getBand(i, addData=True)
        time = 0
        # assign data to correct objects row by row
        for row in dataReader:
            time += (1 / Electrode.Frequency)
            Electrode.timeEEG.append(time)
            Electrode.timeBands.append(time)
            for i, value in enumerate(row):
                currElectrode = getElectrode(i)

                # handle columns that don't contain electrode data
                if currElectrode is None:
                    continue

                if isRawEEG(i):
                    value, stdDev, isPeak, movingAvg, upperBound, lowerBound, trainingFreq = unpackFeatures(value)
                    currElectrode.RawEEG.Values.append(value)
                    currElectrode.RawEEG.StdDeviationValues.append(stdDev)
                    currElectrode.RawEEG.MovingAvgValues.append(movingAvg)
                    currElectrode.RawEEG.UpperBounds.append(upperBound)
                    currElectrode.RawEEG.LowerBounds.append(lowerBound)
                    writeTrainingPoint(currElectrode.RawEEG, trainingFreq, value)
                    writePeak(currElectrode.RawEEG, isPeak, time, value)

                if isBand(i):
                    bandType = getBand(i)
                    value, stdDev, isPeak, movingAvg, upperBound, lowerBound, trainingFreq = unpackFeatures(value)
                    if bandType == "alpha":
                        currElectrode.Alpha.Values.append(value)
                        currElectrode.Alpha.StdDeviationValues.append(stdDev)
                        currElectrode.Alpha.MovingAvgValues.append(movingAvg)
                        currElectrode.Alpha.UpperBounds.append(upperBound)
                        currElectrode.Alpha.LowerBounds.append(lowerBound)
                        writeTrainingPoint(currElectrode.Alpha, trainingFreq, value)
                        writePeak(currElectrode.Alpha, isPeak, time, value)
                        continue
                    if bandType == "theta":
                        currElectrode.Theta.Values.append(value)
                        currElectrode.Theta.StdDeviationValues.append(stdDev)
                        currElectrode.Theta.MovingAvgValues.append(movingAvg)
                        currElectrode.Theta.UpperBounds.append(upperBound)
                        currElectrode.Theta.LowerBounds.append(lowerBound)
                        writeTrainingPoint(currElectrode.Theta, trainingFreq, value)
                        writePeak(currElectrode.Theta, isPeak, time, value)
                        continue
                    if bandType == "betaL":
                        currElectrode.BetaL.Values.append(value)
                        currElectrode.BetaL.StdDeviationValues.append(stdDev)
                        currElectrode.BetaL.MovingAvgValues.append(movingAvg)
                        currElectrode.BetaL.UpperBounds.append(upperBound)
                        currElectrode.BetaL.LowerBounds.append(lowerBound)
                        writeTrainingPoint(currElectrode.BetaL, trainingFreq, value)
                        writePeak(currElectrode.BetaL, isPeak, time, value)
                        continue
                    if bandType == "betaH":
                        currElectrode.BetaH.Values.append(value)
                        currElectrode.BetaH.StdDeviationValues.append(stdDev)
                        currElectrode.BetaH.MovingAvgValues.append(movingAvg)
                        currElectrode.BetaH.UpperBounds.append(upperBound)
                        currElectrode.BetaH.LowerBounds.append(lowerBound)
                        writeTrainingPoint(currElectrode.BetaH, trainingFreq, value)
                        writePeak(currElectrode.BetaH, isPeak, time, value)
                        continue
                    if bandType == "gamma":
                        currElectrode.Gamma.Values.append(value)
                        currElectrode.Gamma.StdDeviationValues.append(stdDev)
                        currElectrode.Gamma.MovingAvgValues.append(movingAvg)
                        currElectrode.Gamma.UpperBounds.append(upperBound)
                        currElectrode.Gamma.LowerBounds.append(lowerBound)
                        writeTrainingPoint(currElectrode.Gamma, trainingFreq, value)
                        writePeak(currElectrode.Gamma, isPeak, time, value)
                        continue

    print(Electrode.freqNamesOutput)


def writePeak(EEGDataType, isPeak, time, value):
    if isPeak:
        if not value is None:
            EEGDataType.PeakPoints.append((time, value))


def writeTrainingPoint(EEGDataType, trainFreq, value):
    if trainFreq is not None and value is not None:
        EEGDataType.TrainingPoints.append((value, trainFreq))


def transformData(value):
    try:
        value = float(value)
    except ValueError:
        value = None
    return value


def isRawEEG(i):
    return indexElectrodeNames <= i < indexElectrodeNames + numElectrodes


def isBand(i):
    return indexBands <= i < indexBands + numBands


def isEEGStd(i):
    return indexEEGStd <= i < indexEEGStd + numElectrodes


def unpackFeatures(dataChunk):
    try:
        value, stdDev, isPeak, movingAvg, upperBound, lowerBound, trainingFreq = dataChunk.split("/")
        value = transformData(value.strip())
        stdDev = transformData(stdDev.strip())
        movingAvg = transformData(movingAvg.strip())
        upperBound = transformData(upperBound.strip())
        lowerBound = transformData(lowerBound.strip())
        trainingFreq = transformData(trainingFreq.strip())
        if isPeak.strip() == "false":
            isPeak = False
        else:
            isPeak = True
    except ValueError:
        value = stdDev = movingAvg = upperBound = lowerBound = trainingFreq = None
        isPeak = False
    return value, stdDev, isPeak, movingAvg, upperBound, lowerBound, trainingFreq


def getElectrode(i):
    try:
        name, dataType = Electrode.header[i].split("/")
    # handle case where no '/' is present
    except ValueError:
        name = Electrode.header[i]
    name = name.strip()
    # handle case where no '/' is present and it's not an electrode column... i.e. timestamp
    try:
        return Electrode.electrodeDict[name]
    except KeyError:
        return None


def getBand(i, addData=False):
    name, dataType = Electrode.header[i].split("/")
    if addData:
        Electrode.freqNamesOutput.append(Electrode.header[i].strip()+"/std")
    return dataType.strip()


createVisualizations()
