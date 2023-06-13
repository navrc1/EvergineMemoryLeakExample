using System;
using Evergine.Framework.Services;

namespace UIWindowSystemsDemo
{
    public class InteractionService : Service
    {
        public event EventHandler CameraReset;
        public bool ResizeSpheres { get; set; } = false;

        public float Displacement { get; set; }

        public void ResetCamera()
        {
            this.CameraReset?.Invoke(this, EventArgs.Empty);
        }
    }
}
