# M2Motion
version0.2
Ip should be 192.169.102.12    
This version allows M2 to simultaneously acquire motion data and EMG data.

## Steps
1. Connect the M2 and Delsys.
2. Switch on M2 and Delsys.
3. Open the Trigno Control Utility, and start analog.
4. Open the M2Motion.
5. Enter the MassSim.
6. Press the Connect, Return and Release buttons in turn. Wait 10 seconds, go back to the desktop and turn off the report mistake of Delsys.
7. Press the Return and Release buttons, you can see the number of trial increase. The data records when you press Release button. If the number reach your set in config.csv, press stop.
8. Press ReturnMain and Exit in turn.  

## attention
1. The data starts nearly the 90 line. This is because Delsys needs time to establishing a connection.
2. The Configuration file should be put in D://MotionConfig//. The first line is header. The second line is setting for the mistake of Delsys, and the Factor of this line is the trial number. I gave an example of a configuration file in the folder.  
3. Path is the filename of data. If your trial number is 3 and the Path is "test", the name of data should be test0.csv, test1.csv, test2.csv and test3.csv.

## Ori position and Dst position
* The range of OriX and DstX are between 10000 and 150000.
* The range of OriY and DstY are between 10000 and 110000.
* The range of Mass is between 10000 and 50000. (50000 is lighter.)
* The range of Factor is between 0 and 3000. (0 is lighter.)
