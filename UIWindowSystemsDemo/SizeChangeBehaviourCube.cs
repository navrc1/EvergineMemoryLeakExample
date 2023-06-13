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
    public class SizeChangeBehaviorCube : Behavior {
        [BindService(isRequired: false)]
        protected InteractionService service;

        [BindComponent]
        protected CubeMesh cube;
        
        protected override void OnActivated() {
            base.OnActivated();
        }

        TimeSpan TotalTime = TimeSpan.Zero;

        protected override void Update(TimeSpan gameTime) {
            TotalTime += gameTime;
            var size = (float)Math.Sin(TotalTime.TotalSeconds) + 1.1f;
            cube.Size = size;
        }
    }
}
