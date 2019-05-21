﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KyThuatDoHoa_Nhom9.Construct.DefineType;

namespace KyThuatDoHoa_Nhom9.Construct._2DObject
{
    public class Timepiece : Shapes2DObject, INotifyPropertyChanged
    {
        private Point location;
        private DateTime time;
        private Clock clock;
        private Pendulum pendulum;

        public Point Location { get => location; set => location = value; }
        public DateTime Time { get => time; set => time = value; }

        public event PropertyChangedEventHandler PropertyChanged;



        public Timepiece()
        {
            this.Location = new Point(0, 0);
            this.Time = DateTime.Now;
        }

        public Timepiece(DateTime time, Point location)
        {
            this.Location = location;
            this.Time = time;
        }

        public void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public void Init(Point start, Point end, Size sizeOfLine, Color color)
        {
            throw new NotImplementedException();
        }

        public void Rotate(Point p, double alpha)
        {
            throw new NotImplementedException();
        }

        public void Scale(SizeF scaleSize)
        {
            throw new NotImplementedException();
        }

        public void Shifting(Point pDest)
        {
            throw new NotImplementedException();
        }

        public void Symmetry(Point orgin, SymmetryMode mode)
        {
            throw new NotImplementedException();
        }
    }
}
