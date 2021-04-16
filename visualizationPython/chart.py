import numpy as np
from plotly.subplots import make_subplots
import plotly.graph_objects as go
import matplotlib.pyplot as plt


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
    bandTimes = np.array(times)[bandMask]

    eegMask = np.isfinite(eegRaw)
    eegTimes = np.array(times)[eegMask]

    setBounds(electrode)

    bandBoundTimes = np.array(times)[electrode.BandBoundMask]
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

    # set x labels
    axs[0, 0].set(ylabel='Signal Values')
    axs[1, 0].set(ylabel='Signal Values')
    # set y labels
    axs[1, 0].set(xlabel='Time (ms)')
    axs[1, 1].set(xlabel='Time (ms)')
    axs[1, 2].set(xlabel='Time (ms)')

    plt.show()


def chartPeak(subplot, EEGData, setLabel=False):
    xVals = [x[0] for x in EEGData.PeakPoints]
    yVals = [x[1] for x in EEGData.PeakPoints]
    if setLabel:
        subplot.plot(xVals, yVals, 'bo', label="Blinks")
    else:
        subplot.plot(xVals, yVals, 'bo')


def chartEEG(electrode, title="Signal vs. Time"):
    times = electrode.timeEEG
    signal = electrode.RawEEG.Values
    signal = np.array(signal).astype(np.float)
    signalMask = np.isfinite(signal)
    signalTimes = np.array(times)[signalMask]

    boundTimes = np.array(times)[electrode.RawEEGBoundMask]

    plt.plot(signalTimes, signal[signalMask], '-')
    plt.fill_between(boundTimes, electrode.RawEEG.LowerBounds, electrode.RawEEG.UpperBounds, facecolor='red', alpha=0.5)

    plt.ylabel('Value')
    plt.xlabel("Time")
    plt.title(title)
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