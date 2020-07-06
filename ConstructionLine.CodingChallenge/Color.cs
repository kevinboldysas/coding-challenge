using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Color
    {
        private static readonly Color red = new Color(Guid.NewGuid(), "Red");
        private static readonly Color blue = new Color(Guid.NewGuid(), "Blue");
        private static readonly Color yellow = new Color(Guid.NewGuid(), "Yellow");
        private static readonly Color white = new Color(Guid.NewGuid(), "White");
        private static readonly Color black = new Color(Guid.NewGuid(), "Black");

        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static Color Red
        {
            get
            {
                return red;
            }
        }

        public static Color Blue
        {
            get
            {
                return blue;
            }
        }

        public static Color Yellow
        {
            get
            {
                return yellow;
            }
        }

        public static Color White
        {
            get
            {
                return white;
            }
        }

        public static Color Black
        {
            get
            {
                return black;
            }
        }

        public static readonly List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };
    }
}