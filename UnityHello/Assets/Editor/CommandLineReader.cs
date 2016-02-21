#region Author
/************************************************************************************************************
Author: EpixCode (Keven Poulin)
Website: http://www.EpixCode.com
GitHub: https://github.com/EpixCode
Twitter: https://twitter.com/EpixCode (@EpixCode)
LinkedIn: http://www.linkedin.com/in/kevenpoulin
************************************************************************************************************/
#endregion

#region Copyright
/************************************************************************************************************
Copyright (C) 2013 EpixCode
Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute,
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished 
to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING 
BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
************************************************************************************************************/
#endregion

#region Class Documentation
/************************************************************************************************************
Class Name:     CommandLineReader.cs
Namespace:      Com.EpixCode.Util
Type:           Util, Static
Definition:
                CommandLineReader.cs give the ability to access [Custom Arguments] sent 
                through the command line. Simply add your custom arguments under the
                keyword '-CustomArgs:' and seperate them by ';'.
Example:
                C:\Program Files (x86)\Unity\Editor\Unity.exe [ProjectLocation] -executeMethod [Your entrypoint] -quit -CustomArgs:Language=en_US;Version=1.02
                
************************************************************************************************************/
#endregion

#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#endregion

public class CommandLineReader
{
    //Config
    private const string CUSTOM_ARGS_PREFIX = "-CustomArgs:";
    private const char CUSTOM_ARGS_SEPARATOR = ';';

    public static string[] GetCommandLineArgs()
    {
        return Environment.GetCommandLineArgs();
    }

    public static string GetCommandLine()
    {
        string[] args = GetCommandLineArgs();

        if (args.Length > 0)
        {
            return string.Join(" ", args);
        }
        else
        {
            Debug.LogError("CommandLineReader.cs - GetCommandLine() - Can't find any command line arguments!");
            return "";
        }
    }

    public static Dictionary<string, string> GetCustomArguments()
    {
        Dictionary<string, string> customArgsDict = new Dictionary<string, string>();
        string[] commandLineArgs = GetCommandLineArgs();
        string[] customArgs;
        string[] customArgBuffer;
        string customArgsStr = "";

        try
        {
            customArgsStr = commandLineArgs.Where(row => row.Contains(CUSTOM_ARGS_PREFIX)).Single();
        }
        catch (Exception e)
        {
            Debug.LogError("CommandLineReader.cs - GetCustomArguments() - Can't retrieve any custom arguments in the command line [" + commandLineArgs + "]. Exception: " + e);
            return customArgsDict;
        }

        customArgsStr = customArgsStr.Replace(CUSTOM_ARGS_PREFIX, "");
        customArgs = customArgsStr.Split(CUSTOM_ARGS_SEPARATOR);

        foreach (string customArg in customArgs)
        {
            customArgBuffer = customArg.Split('=');
            if (customArgBuffer.Length == 2)
            {
                customArgsDict.Add(customArgBuffer[0], customArgBuffer[1]);
            }
            else
            {
                Debug.LogWarning("CommandLineReader.cs - GetCustomArguments() - The custom argument [" + customArg + "] seem to be malformed.");
            }
        }

        return customArgsDict;
    }

    public static string GetCustomArgument(string argumentName)
    {
        Dictionary<string, string> customArgsDict = GetCustomArguments();

        if (customArgsDict.ContainsKey(argumentName))
        {
            return customArgsDict[argumentName];
        }
        else
        {
            Debug.LogError("CommandLineReader.cs - GetCustomArgument() - Can't retrieve any custom argument named [" + argumentName + "] in the command line [" + GetCommandLine() + "].");
            return "";
        }
    }
}