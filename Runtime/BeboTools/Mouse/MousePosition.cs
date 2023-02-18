using UnityEngine;
using UnityEngine.InputSystem;

namespace BeboTools
{
    /// <summary>
    /// Static class for getting various roundings of mouse position.
    /// Before calling any rounding functions, set the RoundingFactor property to desired value.
    /// Defaults to "1"
    /// </summary>
    public static class MousePosition
    {
        public static float RoundingFactor { get; set; }
        
        private static readonly Camera camera;
        private static Plane plane;
        
        static MousePosition()
        {
            camera = Camera.main;
            plane = new Plane(Vector3.up, 0);
            RoundingFactor = 1;
        }

        /// <summary>
        /// Returns the real x and z position of the mouse in real world coordinates. (y is always 0)
        /// </summary>
        /// <returns>Vector3</returns>

        public static Vector3 Actual {
            get
            {
                Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (plane.Raycast(ray, out float enterPoint))
                {
                    Vector3 point = ray.GetPoint(enterPoint);
                    return new Vector3(point.x, 0, point.z);
                }
                return Vector3.zero;
            }
        }

        /// <summary>
        /// Returns the rounded x and z position to the nearest multiple of the set RoundingFactor. (y is always 0)
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 Rounded
        {
            get
            {
                Vector3 pos = Actual.Round(RoundingFactor);
                return new Vector3(pos.x, 0, pos.z);
            }
        }

        /// <summary>
        /// Returns the rounded up x and z position to the nearest multiple of the set RoundingFactor. (y is always 0)
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 RoundedUp
        {
            get
            {
                Vector3 pos = Actual.RoundUp(RoundingFactor);
                return new Vector3(pos.x, 0, pos.z);
            }
        }

        /// <summary>
        /// Returns the rounded down x and z position to the nearest multiple of the set RoundingFactor. (y is always 0)
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 RoundedDown
        {
            get
            {
                Vector3 pos = Actual.RoundDown(RoundingFactor);
                return new Vector3(pos.x, 0, pos.z);
            }
        }

        /// <summary>
        /// Returns the rounded x and z position halfway between the multiple of the RoundingFactor. (y is always 0)
        /// For Example: Mouse position: (1.75, 1, 1.35), RoundingFactor: 2, Will return Vector3(1, 0, 1)
        /// </summary>
        /// <returns>Vector3</returns>
        public static Vector3 RoundedMiddle
        {
            get
            {
                Vector3 pos = Actual.RoundDown(RoundingFactor);
                return new Vector3(pos.x + RoundingFactor /2f, 0, pos.z + RoundingFactor /2f);
            }
        }
    }
}