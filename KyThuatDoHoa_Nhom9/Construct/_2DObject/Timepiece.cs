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
        private Clock item_clock;
        private Pendulum item_pendulum;
        private bool displayNow;

        public Point Location { get => location;
            set
            {
                if(value != this.location)
                {
                    this.location = value;
                    OnPropertyChanged("location");
                }
            }
        }

        public bool DisplayNow { get => displayNow; set => displayNow = value; }
        public Clock Item_clock { get => item_clock;
            set
            {
                if(value != this.item_clock)
                {
                    this.item_clock = value;
                    OnPropertyChanged("item_clock");
                }
            }
        }

        public Pendulum Item_pendulum { get => item_pendulum;
            set
            {
                if(value != this.item_pendulum)
                {
                    this.item_pendulum = value;
                    OnPropertyChanged("item_pendulum");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public Timepiece()
        {
            Setup();
            this.Location = new Point(0, 0);
            this.Item_clock.PropertyChanged += Item_clock_PropertyChanged;
            this.Item_clock.CurrentDatetime = DateTime.Now;
            if(this.Item_clock != null && this.Item_pendulum != null)
            {
                this.Item_clock.PropertyChanged += Clock_PropertyChanged;
                this.Item_pendulum.PropertyChanged += Pendulum_PropertyChanged;
            }
        }

        private void Item_clock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("item_clock");
        }

        public Timepiece(DateTime time, Point location)
        {
            Setup(time, location);
            this.Location = location;

            if (this.Item_clock != null && this.Item_pendulum != null)
            {
                this.Item_clock.PropertyChanged += Clock_PropertyChanged;
                this.Item_pendulum.PropertyChanged += Pendulum_PropertyChanged;
            }
        }

        private void Pendulum_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("nextStep"))
                this.DisplayNow = true;
        }

        private void Clock_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public void Draw(Graphics g)
        {
            this.Item_clock.Draw(g);
            this.Item_pendulum.Draw(g);
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

        private void Setup()
        {
            if(this.Item_clock == null)
            {
                this.Item_clock = new Clock(new Point(this.Location.X + 20, this.Location.Y + 10), 15, DateTime.Now);
            }
            if(this.Item_pendulum == null)
            {
                this.Item_pendulum = new Pendulum(ToaDo.NguoiDungMayTinh(new Point(this.Location.X + 1, this.Location.Y - 6)), ToaDo.NguoiDungMayTinh(new Point(this.Location.X + 40, this.Location.Y + -60)));
            }
        }

        private void Setup(DateTime time, Point p)
        {
            if (this.Item_clock == null)
            {
                this.Item_clock = new Clock(ToaDo.NguoiDungMayTinh(new Point(p.X + 30, p.Y + 5)), 15, time);
            }
            if (this.Item_pendulum == null)
            {
                this.Item_pendulum = new Pendulum(ToaDo.NguoiDungMayTinh(new Point(p.X + 10, p.Y - 13)), ToaDo.NguoiDungMayTinh(new Point(p.X + 50, p.Y + -60)));
            }
        }

        private void ChangeObject(Point p)
        {
            //this.clock.A = new Point(p.X + 100, p.Y + 50);
            //this.pendulum.Rectangle
        }
    }
}
