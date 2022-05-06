﻿using GraphsAlgorithms.Model.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphsAlgorithms.Model
{
    static class ElipseTools
    {
        public static bool PointInElipse(Point p, double x, double y, double R)
        {
            if ((Math.Pow((p.X - x),2)  / Math.Pow(R,2)) + (Math.Pow((p.Y - y), 2) / Math.Pow(R, 2)) < 1) return true;
            else return false;
        }
        public static Edge PointInText(GraphModel gm, Point p)
        {
            foreach (var edges in gm.Edges)
            {
                if (Math.Pow(p.X - ((edges.Vertex1.X + edges.Vertex2.X) / 2), 2) + Math.Pow(p.Y - ((edges.Vertex1.Y + edges.Vertex2.Y) / 2), 2) <= Math.Pow(25, 2))
                {
                    GraphsAlgorithms.View.PathDialog pathDialog = new GraphsAlgorithms.View.PathDialog();

                    if (pathDialog.ShowDialog() == true)
                    {
                        if (pathDialog.Price != "" || pathDialog.Price != null)
                        {
                            Edge n = edges;
                            n.Weight = pathDialog.Price;
                            return n;
                        }
                    }
                }
            }
            return null;
            //(x - x0)^2 + (y - y0)^2 <= R^2
        }
    }
}
