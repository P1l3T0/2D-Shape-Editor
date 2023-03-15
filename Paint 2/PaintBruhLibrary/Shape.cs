﻿using System;
using System.Drawing;

namespace PaintBruhLibrary
{
    [Serializable]
    public abstract class Shape
    {
        public Point location { get; set; }

        public Color colorBorder { get; set; }

        public Color colorFill { get; set; }

        public Color _color { get; set; }

        public virtual float area { get; }

        public virtual int shapeNumber { get; set; }

        [NonSerialized]
        protected internal bool _isSelected;
        public bool isSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        public abstract void PaintShape(IGraphics graphics);

        public abstract bool PointInShape(Point point);
    }
}
