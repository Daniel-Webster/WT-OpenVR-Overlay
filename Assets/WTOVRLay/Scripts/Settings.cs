using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings
{
    private Settings(bool PrintEvents, bool PrintInfo) {
        this.PrintEvents = PrintEvents;
        this.PrintInfo = PrintInfo;
    }
    public static Settings Unity = new Settings(true, true);
    public bool PrintEvents {get;set;}
    public bool PrintInfo {get;set;}

}
