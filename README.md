# M2Motion
version 0.6
Ip should be 192.169.102.12 
Unity version: 5.3.4f1   
This version allows M2 to complete the inertia load simulation, while outtputing trigger signal(a falling edge).

## Steps
1. Connect the M2, Data Acquisition Card and Delsys.
2. Switch on M2 and Delsys.
3. Open the EMGworks Acquisition, and ready to record.
4. Open the UDPserver, M2Motion and connect the DIO0 and GND of Data Acquisition Card to the sensor.
5. Enter the MassSim in M2motion, press connect button to connect M2.
6. Open the EMG sensor, start EMG record.
7. Press the Return(keyboard A) and Release(keyboard S) buttons, you can see the number of trial increase. The data records when you press Release button(DIO0 -> 0v). If the number reach your set in config.csv, press stop(keyboard D).
8. Press ReturnMain and Exit in turn.  

## attention
1. The Configuration file should be put in D://MotionConfig//. The first line is header. The second line is setting for the test of Delsys, and the Factor of this line is the trial number. I gave an example of a configuration file in the folder.  
2. Path is the filename of data. If your trial number is 3 and the Path is "test", the name of data should be test0.csv, test1.csv, test2.csv and test3.csv.

## MotionConfig
* The task number 0 means sham, and number 1 means mass simulation.
* The range of OriX and DstX are between 10000 and 150000.
* The range of OriY and DstY are between 10000 and 110000.
* The range of Mass is between 20 and 100. (100 is lighter.)
* The range of Factor is between 1000 and 8000. (1000 is lighter.)

## data
* The first two columns are x, y coordinate values.
* The third and fourth columns are x, y velocity values.
* The fifth and sixth columns are x, y RedunTorData values.
* The seventh and eighth columns are x, y RedunTorData values.
* The ninth column is trigger.