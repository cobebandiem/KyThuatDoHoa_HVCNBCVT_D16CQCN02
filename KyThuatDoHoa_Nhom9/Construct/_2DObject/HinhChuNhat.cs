﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KyThuatDoHoa_Nhom9.Construct.DefineType;

namespace KyThuatDoHoa_Nhom9.Construct._2DObject
{
    class HinhChuNhat : Shapes2DObject
    {
        private Point _a;
        private Point _b;
        private Point _c;
        private Point _d;

        public Point A { get => _a; set => _a = value; }
        public Point B { get => _b; set => _b = value; }
        public Point C { get => _c; set => _c = value; }
        public Point D { get => _d; set => _d = value; }

        public void Draw(Graphics g)
        {
            //Line line;
            //line = new Line(this.A, new Point(this.B.X,this.A.Y));
            //line.Draw(g);
            //line = new Line(new Point(this.B.X, this.A.Y), this.B);
            //line.Draw(g);
            //line = new Line( new Point(this.A.X, this.B.Y),this.B);
            //line.Draw(g);
            //line = new Line(this.A, new Point(this.A.X, this.B.Y));
            //line.Draw(g);

            Line line;
            line = new Line(this.A, this.B);
            line.Draw(g);
            line = new Line(this.B, this.C);
            line.Draw(g);
            line = new Line( this.D, this.C);
            line.Draw(g);
            line = new Line(this.A, this.D);
            line.Draw(g);


        }
        public HinhChuNhat(Point start, Point end)
        {
            this.A = start;
            this.B = new Point(end.X, start.Y);
            this.C = end;
            this.D = new Point(start.X, end.Y);
        }
        public void Init(Point start, Point end, Size sizeOfLine, Color color)
        {
            throw new NotImplementedException();
        }

        public void Rotate(Point p, double alpha)
        {
            this.A = this.A.RotateAt(p, (int)alpha);
            this.B = this.B.RotateAt(p, (int)alpha);
            this.C = this.C.RotateAt(p, (int)alpha);
            this.D = this.D.RotateAt(p, (int)alpha);

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

        private void CalAndUpdateNewLoca(float[][] matrix_Trans)
        {
            int[][] matrix_Point = {
                new int[] {this.A.X},
                new int[] {this.A.Y},
                new int[] {1},
             };

            int[][] newPoint = Matrixs.Multiply(matrix_Trans, matrix_Point);

            _a.X = newPoint[0][0];
            _a.Y = newPoint[1][0];

            matrix_Point[0][0] = this.B.X;
            matrix_Point[1][0] = this.B.Y;
            newPoint = Matrixs.Multiply(matrix_Trans, matrix_Point);
            _b.X = newPoint[0][0];
            _b.Y = newPoint[1][0];

            matrix_Point[0][0] = this.C.X;
            matrix_Point[1][0] = this.C.Y;
            newPoint = Matrixs.Multiply(matrix_Trans, matrix_Point);
            _c.X = newPoint[0][0];
            _c.Y = newPoint[1][0];

            matrix_Point[0][0] = this.D.X;
            matrix_Point[1][0] = this.D.Y;
            newPoint = Matrixs.Multiply(matrix_Trans, matrix_Point);
            _d.X = newPoint[0][0];
            _d.Y = newPoint[1][0];
        }
    }
}