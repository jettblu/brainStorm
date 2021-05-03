import numpy as np
import matplotlib.pyplot as plt
import copy


def chartElectrode(electrode):
    fig, axs = plt.subplots(2, 3, sharex=True)
    fig.suptitle(electrode.Name)

    times = electrode.timeEEG
    eegRaw = np.array(electrode.RawEEG.Values).astype(np.float)
    eegRawMovingAvg = np.array(electrode.RawEEG.MovingAvgValues).astype(np.float)

    alpha = np.array(electrode.Alpha.Values).astype(np.float)
    theta = np.array(electrode.Theta.Values).astype(np.float)
    betaL = np.array(electrode.BetaL.Values).astype(np.float)
    betaH = np.array(electrode.BetaH.Values).astype(np.float)
    gamma = np.array(electrode.Gamma.Values).astype(np.float)

    alphaMovingAvg = np.array(electrode.Alpha.MovingAvgValues).astype(np.float)
    thetaMovingAvg = np.array(electrode.Theta.MovingAvgValues).astype(np.float)
    betaLMovingAvg = np.array(electrode.BetaL.MovingAvgValues).astype(np.float)
    betaHMovingAvg = np.array(electrode.BetaH.MovingAvgValues).astype(np.float)
    gammaMovingAvg = np.array(electrode.Gamma.MovingAvgValues).astype(np.float)

    bandMask = np.isfinite(theta)
    eegMask = np.isfinite(eegRaw)

    # make lists same length
    bandTimesTrimmed, bandMaskTrimmed = trimLists(times, bandMask)

    bandTimes = np.array(bandTimesTrimmed)[bandMaskTrimmed]

    # make lists same length
    eegTimesTrimmed, eegMaskTrimmed = trimLists(times, eegMask)

    eegTimes = np.array(eegTimesTrimmed)[eegMaskTrimmed]

    setBounds(electrode)

    bandBoundTimes = np.array(bandTimesTrimmed)[electrode.BandBoundMask]
    eegBoundTimes = np.array(times)[electrode.RawEEGBoundMask]

    axs[0, 0].plot(eegTimes, eegRaw[eegMask], label="Signal")
    axs[0, 0].plot(eegTimes, eegRawMovingAvg[eegMask], 'm-', label="MovingAvg")
    axs[0, 0].fill_between(eegBoundTimes, electrode.RawEEG.LowerBounds, electrode.RawEEG.UpperBounds, facecolor='red',
                           alpha=0.5, label="Dynamic Bounds")
    chartPeak(axs[0, 0], electrode.RawEEG, setLabel=True)
    axs[0, 0].set_title('EEG RAW')

    axs[0, 1].plot(bandTimes, alpha[bandMask], '-')
    axs[0, 1].fill_between(bandBoundTimes, electrode.Alpha.LowerBounds, electrode.Alpha.UpperBounds, facecolor='red',
                           alpha=0.5)
    axs[0, 1].plot(bandTimes, alphaMovingAvg[bandMask], 'm-')
    chartPeak(axs[0, 1], electrode.Alpha)
    axs[0, 1].set_title('Alpha')

    axs[0, 2].plot(bandTimes, theta[bandMask], '-')
    axs[0, 2].fill_between(bandBoundTimes, electrode.Theta.LowerBounds, electrode.Theta.UpperBounds, facecolor='red',
                           alpha=0.5)
    axs[0, 2].plot(bandTimes, thetaMovingAvg[bandMask], 'm-')
    chartPeak(axs[0, 2], electrode.Theta)
    axs[0, 2].set_title('Theta')

    axs[1, 0].plot(bandTimes, betaL[bandMask], '-')
    axs[1, 0].fill_between(bandBoundTimes, electrode.BetaL.LowerBounds, electrode.BetaL.UpperBounds, facecolor='red',
                           alpha=0.5)
    axs[1, 0].plot(bandTimes, betaLMovingAvg[bandMask], 'm-')
    chartPeak(axs[1, 0], electrode.BetaL)
    axs[1, 0].set_title('Beta Low')

    axs[1, 1].plot(bandTimes, betaH[bandMask], '-')
    axs[1, 1].fill_between(bandBoundTimes, electrode.BetaH.LowerBounds, electrode.BetaH.UpperBounds, facecolor='red',
                           alpha=0.5)
    axs[1, 1].plot(bandTimes, betaHMovingAvg[bandMask], 'm-')
    chartPeak(axs[1, 1], electrode.BetaH)
    axs[1, 1].set_title('Beta High')

    axs[1, 2].plot(bandTimes, gamma[bandMask], '-')
    axs[1, 2].fill_between(bandBoundTimes, electrode.Gamma.LowerBounds, electrode.Gamma.UpperBounds, facecolor='red',
                           alpha=0.5)
    axs[1, 2].plot(bandTimes, gammaMovingAvg[bandMask], 'm-')
    chartPeak(axs[1, 2], electrode.Gamma)
    axs[1, 2].set_title('Gamma')

    # set legend
    fig.legend()

    # set y labels
    axs[0, 0].set(ylabel='Signal Values')
    axs[1, 0].set(ylabel='Signal Values')
    # set x labels
    axs[1, 0].set(xlabel='Time (ms)')
    axs[1, 1].set(xlabel='Time (ms)')
    axs[1, 2].set(xlabel='Time (ms)')

    plt.show()


def chartTrainResponse(electrode):
    fig, axs = plt.subplots(2, 3, sharex=False)
    fig.suptitle(f"{electrode.Name} Train Response")
    # set subplot titles
    axs[0, 0].set_title('EEG RAW')
    axs[0, 1].set_title('Alpha')
    axs[0, 2].set_title('Theta')
    axs[1, 1].set_title('Beta High')
    axs[1, 2].set_title('Gamma')
    # plot response points
    chartResponsePoints(axs[0, 0], electrode.RawEEG, setLabel=True)
    chartResponsePoints(axs[0, 1], electrode.Alpha)
    chartResponsePoints(axs[0, 2], electrode.Theta)
    chartResponsePoints(axs[1, 0], electrode.BetaL)
    chartResponsePoints(axs[1, 1], electrode.BetaH)
    chartResponsePoints(axs[1, 2], electrode.Gamma)

    # set legend
    fig.legend()

    # set y labels
    axs[0, 0].set(ylabel='Frequency')
    axs[1, 0].set(ylabel='Frequency')
    # set x labels
    axs[1, 0].set(xlabel='Signal Value')
    axs[1, 1].set(xlabel='Signal Value')
    axs[1, 2].set(xlabel='Signal Value')

    plt.show()


def chartResponseAcrossElectrodes(electrodeDict, bandName):
    rows = 2
    cols = 7
    fig, axs = plt.subplots(2, 7, sharex=False, sharey=True)

    fig.suptitle(f"Train Response Across {bandName}")
    currCol = 0
    currRow = 0


    for electrodeName in electrodeDict:

        # set y labels for each new row
        if currCol == 0:
            axs[currRow, currCol].set(ylabel="Frequency")

        # set x labels for bottom charts
        if currRow == rows-1:
            for colIndex in range(cols):
                axs[currRow, colIndex].set(xlabel="Signal Value")

        currElectrode = electrodeDict[electrodeName]
        currBand = selectFrequencyBand(bandName=bandName, currElectrode=currElectrode)
        # stop if bandName is not valid
        if currBand is None:
            return
        # set legend labels when first grid is plot
        if currCol == 0 and currRow == 0:
            chartResponsePoints(axs[currRow, currCol], currBand, setLabel=True)
        else:
            chartResponsePoints(axs[currRow, currCol], currBand)

        axs[currRow, currCol].set_title(f"{currElectrode.Name}")

        currCol += 1

        if currCol == cols:
            currCol = 0
            currRow += 1

            if currRow == rows:
                # set legend
                fig.legend()
                plt.show()
                return


def chartPeak(subplot, EEGData, setLabel=False):
    xVals = [x[0] for x in EEGData.PeakPoints]
    yVals = [x[1] for x in EEGData.PeakPoints]

    if setLabel:
        subplot.plot(xVals, yVals, 'bo', label="Blinks", markersize=3)
    else:
        subplot.plot(xVals, yVals, 'bo', markersize=3)


def chartResponsePoints(subplot, EEGData, setLabel=False):
    xVals = [x[0] for x in EEGData.TrainingPoints]
    yVals = [x[1] for x in EEGData.TrainingPoints]

    coef = np.polyfit(xVals, yVals, 1)
    # a function which takes in x and returns an estimate for y
    poly1dFn = np.poly1d(coef)

    if setLabel:
        subplot.plot(xVals, yVals, 'bo', label="Response")
        subplot.plot(xVals, poly1dFn(xVals), '-r', label="1D Regression")
    else:
        subplot.plot(xVals, yVals, 'bo')
        subplot.plot(xVals, poly1dFn(xVals), '-r')


def chartEEG(electrode, title="Signal vs. Time"):
    times = electrode.timeEEG
    signal = electrode.RawEEG.Values
    signal = np.array(signal).astype(np.float)
    signalMask = np.isfinite(signal)
    signalTimes = np.array(times)[signalMask]

    boundTimes = np.array(times)[electrode.RawEEGBoundMask]

    plt.plot(signalTimes, signal[signalMask], '-', label="Signal")
    plt.fill_between(boundTimes, electrode.RawEEG.LowerBounds, electrode.RawEEG.UpperBounds, facecolor='red', alpha=0.5, label="Dynamic Bounds")
    chartPeak(plt, electrode.RawEEG, setLabel=True)
    plt.ylabel('Value')
    plt.xlabel("Time")
    plt.title(title)
    # set legend
    plt.legend()
    plt.show()


def calculateBounds(electrode):
    zThreshold = 3.5
    electrodeEEGTypes = [electrode.RawEEG, electrode.Theta, electrode.Alpha, electrode.BetaL, electrode.BetaH, electrode.Gamma]
    isRawEEG = True
    for EEGData in electrodeEEGTypes:
        for i, value in enumerate(EEGData.MovingAvgValues):
            # is true if matches raweeg index

            # can't calculate bound if raw eeg is None or if std. dev. is None
            try:
                if value is None or EEGData.StdDeviationValues[i] is None:
                    EEGData.UpperBounds.append(None)
                    EEGData.LowerBounds.append(None)
                    continue
            except IndexError:
                EEGData.UpperBounds.append(None)
                EEGData.LowerBounds.append(None)
                continue

            upperEEG = value + zThreshold*EEGData.StdDeviationValues[i]
            lowerEEG = value - zThreshold*EEGData.StdDeviationValues[i]

            EEGData.UpperBounds.append(upperEEG)
            EEGData.LowerBounds.append(lowerEEG)

        # switch which mask to write to depending on whether data is band or raw
        if not isRawEEG:
            EEGData.UpperBounds, electrode.BandBoundMask = convertSignal(EEGData.UpperBounds)
            EEGData.LowerBounds, electrode.BandBoundMask = convertSignal(EEGData.LowerBounds)
        else:
            EEGData.UpperBounds, electrode.RawEEGBoundMask = convertSignal(EEGData.UpperBounds)
            EEGData.LowerBounds, electrode.RawEEGBoundMask = convertSignal(EEGData.LowerBounds)
        isRawEEG = False


def setBounds(electrode):
    electrodeEEGTypes = [electrode.RawEEG, electrode.Theta, electrode.Alpha, electrode.BetaL, electrode.BetaH, electrode.Gamma]
    isRawEEG = True
    for EEGData in electrodeEEGTypes:
        # switch which mask to write to depending on whether data is band or raw
        if not isRawEEG:
            EEGData.UpperBounds, electrode.BandBoundMask = convertSignal(EEGData.UpperBounds)
            EEGData.LowerBounds, electrode.BandBoundMask = convertSignal(EEGData.LowerBounds)
        else:
            EEGData.UpperBounds, electrode.RawEEGBoundMask = convertSignal(EEGData.UpperBounds)
            EEGData.LowerBounds, electrode.RawEEGBoundMask = convertSignal(EEGData.LowerBounds)
        isRawEEG = False


# handle Nones for plotting
def convertSignal(signal):
    signal = np.array(signal).astype(np.float)
    signalMask = np.isfinite(signal)
    return signal[signalMask], signalMask


def trimLists(listA, listB):
    # make lists same length
    listACopy = copy.copy(listA)
    listBCopy = copy.copy(listB)

    while len(listACopy) > len(listB):
        listACopy.pop()

    while len(listBCopy) > (len(listA)):
        listBCopy.pop()

    return listACopy, listBCopy


def selectFrequencyBand(currElectrode, bandName):
    currBand = None
    if bandName == "RawEEG":
        currBand = currElectrode.RawEEG
    elif bandName == "Alpha":
        currBand = currElectrode.Alpha
    elif bandName == "Theta":
        currBand = currElectrode.Theta
    elif bandName == "BetaL":
        currBand = currElectrode.BetaL
    elif bandName == "BetaH":
        currBand = currElectrode.BetaH
    elif bandName == "Gamma":
        currBand = currElectrode.Gamma
    return currBand
