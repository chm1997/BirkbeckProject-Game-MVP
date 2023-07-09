using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestLogHandler : ILogHandler
{
    public FileStream m_FileStream;
    private StreamWriter m_StreamWriter;
    private ILogHandler m_DefaultLogHandler = Debug.unityLogger.logHandler;

    public TestLogHandler(string filepath)
    {
        m_FileStream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        m_StreamWriter = new StreamWriter(m_FileStream);
        //Debug.unityLogger.logHandler = this;
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        if (format == "Close")
        {
            m_FileStream.Close();
        }
        else
        {
            m_StreamWriter.WriteLine(String.Format(format, args));
            m_StreamWriter.Flush();
            //m_DefaultLogHandler.LogFormat(logType, context, format, args);
        }

    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        m_DefaultLogHandler.LogException(exception, context);
    }
}