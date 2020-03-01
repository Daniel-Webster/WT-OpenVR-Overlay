using UnityEngine;
using System;
using System.Collections;

public class WTTexture : WTService
{
    WTEvent.Type updateEvent;
    public WTTexture(string service, WTEvent.Type updateEvent) : base(service, 0) { 
        this.updateEvent = updateEvent;
    }
    
    public Texture2D image;
    void UpdateImage(Texture2D image, byte[] data) {
        this.image = new Texture2D(image.width, image.height);
        this.image.LoadImage(data, false);
        WTEvents.PublishEvent(updateEvent, new WTEvent(this.image));
    }

    public IEnumerator GetTexture()
    {
        return HTTPRequest.GetTextureImage(URL+service, UpdateImage);
    }
}
