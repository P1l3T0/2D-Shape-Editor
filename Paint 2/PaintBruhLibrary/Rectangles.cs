using System;
using System.Drawing;
using PaintBruhLibrary.Exceptions;

namespace PaintBruhLibrary
{
    [Serializable]
    public class Rectangles : Shape
    {
        protected internal int _width;
        protected internal int _height;

        public override int shapeNumber { get => 1; }

        public override float area { get => width * height; }

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

        public override void PaintShape(IGraphics graphics)
        {
            var selectedColorBorder = isSelected ? _color : colorBorder;
            graphics.DrawRectangle(selectedColorBorder, colorFill, location.X, location.Y, width, height);
        }

        public override bool PointInShape(Point point)
        {
            return
                location.X <= point.X && point.X <= location.X + width &&
                location.Y <= point.Y && point.Y <= location.Y + height;
        }

        public Rectangles(Color selectedColorBorder)
        {
            _color = selectedColorBorder;
        }
    }
}
