using System;
using System.Drawing;
using PaintBruhLibrary.Exceptions;

namespace PaintBruhLibrary
{
    [Serializable]
    public class StraightLine : Shape
    {
        protected internal int _width;
        protected internal int _height;

        public Point firstPoint { get; set; }
        public Point lastPoint { get; set; }

        public int width
        {
            get => _width;

            set
            {
                if (value < 0)
                    throw new InvalidValueException("Number must be positive!");

                _width = value;
            }
        }

        public int height
        {
            get => _height;

            set
            {
                if (value < 0)
                    throw new InvalidValueException("Number must be positive!");

                _height = value;
            }
        }

        public override int shapeNumber { get => 4; }

        public override float area { get => (float)(width * height); }

        public override void PaintShape(IGraphics graphics)
        {
            var selectedColorBorder = isSelected ? _color : colorBorder;
            graphics.DrawStraightLine(selectedColorBorder, colorFill, location.X, location.Y, width, height, firstPoint, lastPoint);
        }

        public override bool PointInShape(Point point)
        {
            return
                location.X <= point.X && point.X <= location.X + width &&
                location.Y <= point.Y && point.Y <= location.Y + height;
        }

        public StraightLine(Color selectedColorBorder)
        {
            _color = selectedColorBorder;
        }
    }
}
