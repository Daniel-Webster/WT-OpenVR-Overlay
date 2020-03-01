using UnityEngine;

public class WTLogger 
{
    public enum Type {
        INFO,
        EVENT
    }

    public static void LogEvent(WTEvent.Type t, WTEvent e) {
        Log(Type.EVENT, "Event: " + t + " Published: \r\n" + e.detail);
    }
    public static void LogInfo(string message) {
        Log(Type.INFO, message);
    }
    public static void Log(WTLogger.Type logType, string message) {
        if(!Settings.Unity.PrintInfo && Type.INFO == logType) {
            return;
        }
        if(!Settings.Unity.PrintEvents && Type.EVENT == logType) {
            return;
        }
        Debug.Log(logType + ": \r\n" + message);
    }
}
