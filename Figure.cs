using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Point
    {
        public int x;
        public int y;

        public int toButtom;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Figure
    {
        GameForm g;
        int[,] figureMas;

        ArrayList figure;

        Point rotatePoint;

        public Random rand;

        public Figure(GameForm form)
        {
            g = form;
            rand = new Random();

            int type = rand.Next(1,8);

            figure = new ArrayList();

            switch (type)
            {
                case 1:                                         //Гачок в праву сторону
                    {
                        figure.Add(new Point(5, -2));
                        figure.Add(new Point(5, -1));
                        figure.Add(new Point(5, 0));
                        figure.Add(new Point(6, 0));

                        rotatePoint = (Point)figure[1];
                    }
                    break;
                case 2:                                         //ПРЯМА
                    {
                        figure.Add(new Point(6, -3));
                        figure.Add(new Point(6, -2));
                        figure.Add(new Point(6, -1));
                        figure.Add(new Point(6, 0));

                        rotatePoint = (Point)figure[2];
                    }
                    break;
                case 3:                                        //ЗМІЙКА 1
                    {
                        figure.Add(new Point(5, 0));
                        figure.Add(new Point(5, -1));
                        figure.Add(new Point(6, -1));
                        figure.Add(new Point(6, -2));

                        rotatePoint = (Point)figure[2];
                    }
                    break;
                case 4:                                        //КВАДРАТ
                    {
                        figure.Add(new Point(5, 0));
                        figure.Add(new Point(6, 0));
                        figure.Add(new Point(5, -1));
                        figure.Add(new Point(6, -1));

                        rotatePoint = (Point)figure[1];
                    }
                    break;
                case 5:                                        //ЗМІЙКА 2
                    {
                        figure.Add(new Point(6, 0));
                        figure.Add(new Point(6, -1));
                        figure.Add(new Point(5, -1));
                        figure.Add(new Point(5, -2));

                        rotatePoint = (Point)figure[2];
                    }
                    break;

                case 6:                                        //ГАЧОК 2
                    {
                        figure.Add(new Point(6, -2));
                        figure.Add(new Point(6, -1));
                        figure.Add(new Point(6, 0));
                        figure.Add(new Point(5, 0));

                        rotatePoint = (Point)figure[1];
                    }
                    break;

                case 7:                                        //НЕПЕВНИЙ ХРЕСТИК
                    {
                        figure.Add(new Point(6, 0));
                        figure.Add(new Point(5, 0));
                        figure.Add(new Point(4, 0));
                        figure.Add(new Point(5, -1));

                        rotatePoint = (Point)figure[1];
                    }
                    break;
            }

            int h = rand.Next(0, 4);

            for (int i = 0; i < h; i++)
                rotate();

            setFigureInArray();
            
        }

        public void setFigureInArray()
        {
            foreach (Point p in figure)
            {
                if(!(p.x<0) && !(p.y < 0))
                {
                    g.masiv[p.y, p.x] = 3;
                }
            }
        }

        public void moveBelow()
        {

            foreach (Point p in figure)
            {
                if (!(p.x < 0) && !(p.y < 0))
                {
                    g.masiv[p.y, p.x] = 0;
                }
                
            }
            foreach (Point p in figure)
            {
                p.y += 1;
                if (!(p.x < 0) && !(p.y < 0))
                {
                    g.masiv[p.y, p.x] = 3;
                }
            }

        }

        public void moveToBottom()
        {
            int rows = g.masiv.GetUpperBound(0) + 1;
            int cols = g.masiv.Length / rows;

            Point nearestPoint;

            int min = ((Point)figure[0]).toButtom;

            int counter = 0;

            int tempI, tempJ;

            int[] countArr = new int[4];

            foreach (Point p in figure)
            {
                if (p.y > 0)
                {
                    counter = 0;
                    tempI = p.y;
                    tempJ = p.x;

                    for (int q = tempI+1; ; q++)
                    {
                        if (g.masiv[q, tempJ] == 2 || g.masiv[q, tempJ] == 1)
                        {
                            break;
                        }
                        counter++;
                    }
                    p.toButtom = counter;
                }
            }

            if (counter != 0)
            {

                foreach (Point p in figure)
                {
                    if (p.toButtom < min)
                    {
                        min = p.toButtom;
                    }
                }

                foreach (Point p in figure)
                {
                    if (min == p.toButtom)
                    {
                        nearestPoint = p;
                    }
                }

                foreach (Point p in figure)
                {
                    if (!(p.x < 0) && !(p.y < 0))
                    {
                        g.masiv[p.y, p.x] = 0;
                    }

                }
                foreach (Point p in figure)
                {
                    p.y += min;
                    if (!(p.x < 0) && !(p.y < 0))
                    {
                        g.masiv[p.y, p.x] = 3;
                    }
                }
            }
        }

        public void moveSideways(bool side)
        {
            foreach (Point p in figure)
            {
                if (!(p.x < 0) && !(p.y < 0))
                {
                    g.masiv[p.y, p.x] = 0;
                }

            }
            if (side)
            {
                foreach (Point p in figure)
                {
                    p.x -= 1;
                    if (!(p.x < 0) && !(p.y < 0))
                    {
                        g.masiv[p.y, p.x] = 3;
                    }
                }
            }
            else{
                foreach (Point p in figure)
                {
                    p.x += 1;
                    if (!(p.x < 0) && !(p.y < 0))
                    {
                        g.masiv[p.y, p.x] = 3;
                    }
                }
            }
        }

        public bool allowMoveSideways(bool side)
        {
            int columnIndex = 0;

            int rows = g.masiv.GetUpperBound(0) + 1;
            int cols = g.masiv.Length / rows;

            if (side)
            {
                for(int i = 0; i < cols; i++)
                {
                    for(int j = 0; j < rows; j++)
                    {
                        if (g.masiv[j, i] == 3)
                        {
                            columnIndex = i;
                            break;
                        }
                    }
                    if (columnIndex != 0)
                    {
                        break;
                    }
                }

                for(int i = 0; i < rows; i++)
                {
                    if (g.masiv[i, columnIndex] == 3)
                    {
                        if(g.masiv[i, columnIndex - 1] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            else
            {
                for (int i = cols-1; i >= 0; i--)
                {
                    for (int j = rows-1; j >=0; j--)
                    {
                        if (g.masiv[j, i] == 3)
                        {
                            columnIndex = i;
                            break;
                        }
                    }
                    if (columnIndex != 0)
                    {
                        break;
                    }
                }

                for (int i = 0; i < rows; i++)
                {
                    if (g.masiv[i, columnIndex] == 3)
                    {
                        if (g.masiv[i, columnIndex + 1] != 0)
                        {
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        public void rotate()
        {
            ArrayList tempFigure = CloneAndGetToNewArrayList(figure); //зберігаю значення точок фігури

            bool mistakeFlag = false;

            foreach (Point p in figure)
            {
                if (p != rotatePoint)
                {
                    if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y + 1) // точка, яка знаходить зліва на 1 і знизу на 1 від точки оберту
                    {
                        if (p.x + 2 > 0  && p.x + 2 < 12 && p.y < 22)
                        {
                            p.x += 2;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x && p.y == rotatePoint.y + 1)
                    {
                        if (rotatePoint.x + 1 > 0  && rotatePoint.x + 1 < 11 && p.y - 1 < 22)
                        {
                            p.x = rotatePoint.x + 1;
                            p.y -= 1;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y + 1)
                    {

                        if (rotatePoint.x + 1 > 0 && rotatePoint.x + 1 < 12 && rotatePoint.y - 1 < 22)
                        {
                            p.x = rotatePoint.x + 1;
                            p.y = rotatePoint.y - 1;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y)
                    {
                        if (rotatePoint.x > 0 &&  rotatePoint.x < 12 && p.y - 1 < 22)
                        {
                            p.x = rotatePoint.x;
                            p.y -= 1;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                                
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y - 1)
                    {
                        if (p.x - 2 > 0 && p.x - 2 < 12 && p.y < 22)
                        {
                            p.x -= 2;
                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }
                    else if (p.x == rotatePoint.x && p.y == rotatePoint.y - 1)
                    {

                        if (p.x - 1 > 0 &&  p.x - 1 < 12 && p.y + 1 < 22)
                        {
                            p.x -= 1;
                            p.y += 1;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y - 1)
                    {
                        if (p.x > 0 &&  p.x < 12 && p.y + 2 < 22)
                        {
                            p.y += 2;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y)
                    {
                        if (rotatePoint.x > 0  && rotatePoint.x < 12 && rotatePoint.y + 1 < 22)
                        {
                            p.x = rotatePoint.x;
                            p.y = rotatePoint.y + 1;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }

                    else if (p.x == rotatePoint.x && p.y == rotatePoint.y - 2)
                    {
                        if (p.x - 2 > 0 && p.x - 2 < 12 && p.y + 2 < 22)
                        {
                            p.x -= 2;
                            p.y += 2;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }

                    else if (p.x == rotatePoint.x && p.y == rotatePoint.y - 2)
                    {
                        if ((p.x - 2 > 0)  && (p.x - 2 < 12) && (p.y + 2 < 22))
                        {
                            p.x -= 2;
                            p.y += 2;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x - 2 && p.y == rotatePoint.y)
                    {

                        if (p.x + 2 > 0  && p.x + 2 < 12 && p.y + 2 < 22)
                        {
                            p.x += 2;
                            p.y += 2;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }

                    }


                    else if (p.x == rotatePoint.x && p.y == rotatePoint.y + 2)
                    {
                        if (p.x + 2 > 0  && p.x + 2 < 12 && p.y - 2 < 22)
                        {
                            p.x += 2;
                            p.y -= 2;

                            if (p.y > 0)
                            {
                                if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                                {
                                    mistakeFlag = true;
                                }
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }
                        
                    }


                    else if (p.x == rotatePoint.x + 2 && p.y == rotatePoint.y)
                    {
                        if (p.x - 2 > 0 &&  p.x - 2 < 12 && p.y - 2 < 22)
                        {
                            p.x -= 2;
                            p.y -= 2;

                            if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
                            {
                                mistakeFlag = true;
                            }
                        }
                        else
                        {
                            mistakeFlag = true;
                        }
                        
                    }

                    if (mistakeFlag)
                    {
                        foreach(Point point in figure)
                        {
                            g.masiv[point.y, point.x] = 0;
                        }

                        figure = tempFigure;
                        break;
                    }
                }

            }

            if (!mistakeFlag)
            {

                foreach (Point point in tempFigure)
                {
                    if (!(point.x < 0) && !(point.y < 0))
                    {
                        g.masiv[point.y, point.x] = 0;
                    }
                }

                setFigureInArray();
            }
        }

  //      public void rotate()
        //{
        //    ArrayList tempFigure = CloneAndGetToNewArrayList(figure); //зберігаю значення точок фігури

        //    bool mistakeFlag=false;

        //    foreach (Point p in figure)
        //    {
        //        if (p != rotatePoint)
        //        {
        //            if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y + 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x+2 > 0 && p.y > 0 && p.x+2 < 12 && p.y < 12)
        //                {
        //                    p.x += 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }
                        
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x && p.y == rotatePoint.y + 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (rotatePoint.x + 1 > 0 && p.y - 1 > 0 && rotatePoint.x + 1 < 12 && p.y - 1 < 12)
        //                {
        //                    p.x = rotatePoint.x + 1;
        //                    p.y -= 1;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }


        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y + 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (rotatePoint.x + 1 > 0 && rotatePoint.y - 1 > 0 && rotatePoint.x + 1 < 12 && rotatePoint.y - 1 < 12)
        //                {
        //                    p.x = rotatePoint.x + 1;
        //                    p.y = rotatePoint.y - 1;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                       
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (rotatePoint.x > 0 && p.y - 1 > 0 && rotatePoint.x < 12 && p.y - 1 < 12)
        //                {
        //                    p.x = rotatePoint.x;
        //                    p.y -= 1;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                       
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x + 1 && p.y == rotatePoint.y - 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x-2 > 0 && p.y > 0 && p.x - 2 < 12 && p.y < 12)
        //                {
        //                    p.x -= 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag!=true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x && p.y == rotatePoint.y - 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x - 1 > 0 && p.y+1 > 0 && p.x -1 < 12 && p.y+1 < 12)
        //                {
        //                    p.x -= 1;
        //                    p.y += 1;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y - 1)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x > 0 && p.y + 2 > 0 && p.x < 12 && p.y + 2 < 12)
        //                {
        //                    p.y += 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }



        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x - 1 && p.y == rotatePoint.y)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (rotatePoint.x > 0 && rotatePoint.y + 1 > 0 && rotatePoint.x < 12 && rotatePoint.y + 1 < 12)
        //                {
        //                    p.x = rotatePoint.x;
        //                    p.y = rotatePoint.y + 1;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }

        //            else if(p.x==rotatePoint.x && p.y == rotatePoint.y - 2)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x-2 > 0 && p.y + 2 > 0 && p.x -2 < 12 && p.y + 2 < 12)
        //                {
        //                    p.x -= 2;
        //                    p.y += 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }


        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }

        //            else if (p.x == rotatePoint.x && p.y == rotatePoint.y - 2)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if ((p.x - 2 > 0) && (p.y + 2 > 0) && (p.x - 2 < 12) && (p.y + 2 < 12))
        //                {
        //                    p.x -= 2;
        //                    p.y += 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }




        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x-2 && p.y == rotatePoint.y)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x + 2 > 0 && p.y + 2 > 0 && p.x + 2 < 12 && p.y + 2 < 12)
        //                {
        //                    p.x += 2;
        //                    p.y += 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x && p.y == rotatePoint.y+2)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x + 2 > 0 && p.y - 2 > 0 && p.x + 2 < 12 && p.y - 2 < 12)
        //                {
        //                    p.x += 2;
        //                    p.y -= 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }
        //            else if (p.x == rotatePoint.x+2 && p.y == rotatePoint.y)
        //            {
        //                if (!(p.x < 0) && !(p.y < 0))
        //                    g.masiv[p.y, p.x] = 0;

        //                if (p.x - 2 > 0 && p.y - 2 > 0 && p.x - 2 < 12 && p.y - 2 < 12)
        //                {
        //                    p.x -= 2;
        //                    p.y -= 2;

        //                    if (g.masiv[p.y, p.x] == 1 || g.masiv[p.y, p.x] == 2)
        //                    {
        //                        mistakeFlag = true;
        //                    }
        //                }
        //                else
        //                {
        //                    mistakeFlag = true;
        //                }

                        
                            
                        

        //                if (!(p.x < 0) && !(p.y < 0) && mistakeFlag != true)
        //                    g.masiv[p.y, p.x] = 3;
        //            }

        //            if (mistakeFlag)
        //            {
        //                figure = tempFigure;
        //                break;
        //            }
        //        }

        //    }

        //}

        public ArrayList CloneAndGetToNewArrayList(ArrayList points)
        {
            ArrayList kek = new ArrayList();

            foreach(Point p in points)
            {
                int tempX = p.x;
                int tempY = p.y;

                kek.Add(new Point(tempX, tempY));
            }

            return kek;
        }

        public void disableFigure()
        {
            foreach (Point p in figure)
            {
                if (!(p.x < 0) && !(p.y < 0))
                {
                    g.masiv[p.y, p.x] = 2;
                }
            }
        }

        public bool ElemBelowIs(int digit) //Перевірка, чи під трійкою, яка падає, є якась певна цифра
        {
            int rows = g.masiv.GetUpperBound(0) + 1;
            int cols = g.masiv.Length / rows;

            int indexButtomRow = 0 ;

            for(int i = rows-1; i >=0 ; i--)
            {
                for(int j = cols-1; j >=0; j--)
                {
                    if (g.masiv[i, j] == 3)
                    {
                        indexButtomRow = i;
                        break;
                    }
                }
                if (indexButtomRow != 0)
                {
                    break;
                }
            }

            for(int j = 0; j < cols; j++)
            {
                if (g.masiv[indexButtomRow, j] == 3)
                {
                    if(g.masiv[indexButtomRow+1, j] == digit)
                    {
                        return true;
                    }
                }
            }

            if (indexButtomRow > 1) {
                for (int j = 0; j < cols; j++)
                {
                    if (g.masiv[indexButtomRow-1, j]==3)
                    {
                        if (g.masiv[indexButtomRow, j] == digit)
                        {
                            return true;
                        }
                    }
                        
                }
            }
            return false;
        }

        public void fillArray(string t)
        {
            figureMas = new int[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (t[j*4+i]=='1')
                    {
                        figureMas[i, j] = 1;
                    }
                    else
                    {
                        figureMas[i, j] = 0;
                    }
                }
            }
        }
    }
}
