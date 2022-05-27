using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    public TMPro.TMP_Text vector3Values; //Sets a public text variable which can be found in Unity's inspector window.

    int fileCounter = 0; //Int variable that keeps track on the number of files.
    int buttonPress = 0; //Int variable that keeps track on the number of button presses.

    ArrayList acValues = new ArrayList(); //ArrayList that stores data from x,y and z acceleration.
                                          //https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=net-6.0

    void Update()
    {
        switch (buttonPress) //Switch command that calls actions depending on number of button presses.
        {
            case 1: //If number of button presses is equal to 1.

                acValues.Add(Input.acceleration.x + "\t" + Input.acceleration.y + "\t" + Input.acceleration.z);//Adds acceleration input to acValues.
                                                                                                               //The values are seperated by "\t" (tabulator)
                                                                                                               //to make handling of data in excel file easier.
                Accelerometer(); //Calls the Accelerometer method.
                break;

            case 2: //If number of button presses is equal to 2.

                string filename = Application.dataPath + "/Test"+ fileCounter.ToString() +".csv"; //Creates a new string variable called filename which
                                                                                                  //contains the application run-time data from device and 
                                                                                                  //assigns a name to a newly created file based on amount in fileCounter.
                                                                                                  //This is where the csv file is created.

                File.Delete(filename); //Deletes current filename variable and clears data. (DOES NOT DELETE already created CSV file or data within it!)

                TextWriter tw = new StreamWriter(filename, true); //Allows access to save file on disk (Allows writing to a file:
                                                                  //Description of TextWriter https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter?view=net-6.0
                                                                  //Description of StreamWriter https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0)

                foreach (string obj in acValues) //For each of the string values in acValues
                {
                    tw.WriteLine(obj); //Writes a new line in the file. One line consist of x, y and z values from acValues. 
                }

                tw.Close(); //Closes the file

                fileCounter++; //adds 1 to the fileCounter variable

                buttonPress = 0; //Returns buttonPress variable to 0.
                break;

            default:
                acValues.Clear(); //Clears acValues by default to prepare for another file. 
                break;
        }        
    }

    public void ButtonStartPress() //This function is connected to the button in unity's inspector window.
    {
        buttonPress++; //Adds 1 to the buttonPress variable.
    }
    public void Accelerometer() //This method shows acceleration input on screen
    {
        if (vector3Values) //If vector3Values variable is assigned a text component
            vector3Values.text = "Acceleration " + Input.acceleration.ToString(); //The text component should display "Acceleration" and acceleration values.
    }

    /*public void WriteCSV()
    {
        TextWriter tw = new StreamWriter(filename, true);

        tw.WriteLine(Input.acceleration.ToString());

        tw.Close();
    }*/
}
