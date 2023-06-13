using System;
using Evergine.Common.Input.Mouse;
using Evergine.Common.Input;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Mathematics;
using Evergine.Components.Graphics3D;
using System.Linq;
using System.Diagnostics;

namespace UIWindowSystemsDemo {
    public class SizeChangeBehaviorSphere : Behavior {
        [BindService(isRequired: false)]
        protected InteractionService service;

        [BindComponent]
        protected SphereMesh sphere;
        
        protected override void OnActivated() {
            base.OnActivated();
        }

        TimeSpan TotalTime = TimeSpan.Zero;

        protected override void Update(TimeSpan gameTime) {
            if(service != null && service.ResizeSpheres) {
                TotalTime += gameTime;
                var diameter = (float)Math.Sin(TotalTime.TotalSeconds) + 1.1f;
                sphere.Diameter = diameter;
            }
        }
    }
}
