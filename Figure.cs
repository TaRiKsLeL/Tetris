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

        public Point() { }
    }
    class Figure
    {
        GameForm g;
        
        private static Figure nextFigureObj;

        public ArrayList figure;

        Point rotatePoint;

        public Random rand;

        static bool firstTime = true;

        public Figure()
        {
        }

        public Figure makeNewFigure(GameForm form)
        {
            Figure currentFigureObj =new Figure();
            Point tempRotationPoint = new Point();

            g = form;

            rand = new Random();

            int type = rand.Next(1, 8);

            if (firstTime)
            {
                nextFigureObj = new Figure();
                currentFigureObj.figure = getRandomFIgure(type);
                currentFigureObj.rotatePoint = rotatePoint;
                firstTime = !firstTime;
            }
            else
            {
                currentFigureObj = nextFigureObj.DeepCopy();
            }
             
            nextFigureObj.figure = getRandomFIgure(type);
            nextFigureObj.rotatePoint = rotatePoint;

            setNextFigure(g.nextFigureMasiv, nextFigureObj.figure);

            setFigureInArray(currentFigureObj.figure);

            currentFigureObj.g = form;

            return currentFigureObj;
        }

        public Figure DeepCopy()
        {
            Figure kek = new Figure();
            kek.figure = this.figure;
            kek.rotatePoint = this.rotatePoint;
            return kek;
        }
      
        ArrayList getRandomFIgure(int type)
        {
            ArrayList tempFigure = new ArrayList();

            switch (type)
            {
                case 1:                                         //Гачок в праву сторону
                    {
                        tempFigure.Add(new Point(5, -2));
                        tempFigure.Add(new Point(5, -1));
                        tempFigure.Add(new Point(5, 0));
                        tempFigure.Add(new Point(6, 0));

                        rotatePoint = (Point)tempFigure[1];
                    }
                    break;
                case 2:                                         //ПРЯМА
                    {
                        tempFigure.Add(new Point(6, -3));
                        tempFigure.Add(new Point(6, -2));
                        tempFigure.Add(new Point(6, -1));
                        tempFigure.Add(new Point(6, 0));

                        rotatePoint = (Point)tempFigure[2];
                    }
                    break;
                case 3:                                        //ЗМІЙКА 1
                    {
                        tempFigure.Add(new Point(5, 0));
                        tempFigure.Add(new Point(5, -1));
                        tempFigure.Add(new Point(6, -1));
                        tempFigure.Add(new Point(6, -2));

                        rotatePoint = (Point)tempFigure[2];
                    }
                    break;
                case 4:                                        //КВАДРАТ
                    {
                        tempFigure.Add(new Point(5, 0));
                        tempFigure.Add(new Point(6, 0));
                        tempFigure.Add(new Point(5, -1));
                        tempFigure.Add(new Point(6, -1));

                        rotatePoint = (Point)tempFigure[1];
                    }
                    break;
                case 5:                                        //ЗМІЙКА 2
                    {
                        tempFigure.Add(new Point(6, 0));
                        tempFigure.Add(new Point(6, -1));
                        tempFigure.Add(new Point(5, -1));
                        tempFigure.Add(new Point(5, -2));

                        rotatePoint = (Point)tempFigure[2];
                    }
                    break;

                case 6:                                        //ГАЧОК 2
                    {
                        tempFigure.Add(new Point(6, -2));
                        tempFigure.Add(new Point(6, -1));
                        tempFigure.Add(new Point(6, 0));
                        tempFigure.Add(new Point(5, 0));

                        rotatePoint = (Point)tempFigure[1];
                    }
                    break;

                case 7:                                        //НЕПЕВНИЙ ХРЕСТИК
                    {
                        tempFigure.Add(new Point(6, 0));
                        tempFigure.Add(new Point(5, 0));
                        tempFigure.Add(new Point(4, 0));
                        tempFigure.Add(new Point(5, -1));

                        rotatePoint = (Point)tempFigure[1];
                    }
                    break;
            }

            int h = rand.Next(0, 4);

          for (int i = 0; i < h; i++)
           rotate(tempFigure);

            return tempFigure;
        }

        Point getRotatePoint(ArrayList arrayList)
        { Point rotateP=new Point();

            foreach(Point p in arrayList)
            {
                if (p == rotatePoint)
                {
                    rotateP = rotatePoint;
                }
            }

            return rotateP;
        }
        public void setNextFigure(int[,] arr, ArrayList nextF)
        {
            ArrayList tempFig = CloneAndGetToNewArrayList(nextF);

            foreach (Point point in tempFig)
            {
                point.y += 3;
                point.x -= 3;

                arr[point.y, point.x] = 3;
            }
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        g.tableLayoutPanel2.GetControlFromPosition(j, i).BackgroundImage = g.grayImage;
                    }

                    if (arr[i, j] == 3)
                    {
                        g.tableLayoutPanel2.GetControlFromPosition(j, i).BackgroundImage = g.orangeImage;
                    }

                    if (arr[i, j] == 2)
                    {
                        g.tableLayoutPanel2.GetControlFromPosition(j, i).BackgroundImage = g.redImage;
                    }

                }
            }


            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    arr[i, j] = 0;
                }

            }
        }

        public void setFigureInArray(ArrayList arrayList)
        {
            foreach (Point p in arrayList)
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

        public void rotate(ArrayList fig)
        {
            ArrayList tempFigure = CloneAndGetToNewArrayList(fig); //зберігаю значення точок фігури

            bool mistakeFlag = false;

            if (rotatePoint == null)
            {
                Console.WriteLine("");
            }

            foreach (Point p in fig)
            {
                if (p != rotatePoint)
                {
                    if (p.x == this.rotatePoint.x - 1 && p.y == this.rotatePoint.y + 1) // точка, яка знаходить зліва на 1 і знизу на 1 від точки оберту
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
                        foreach(Point point in fig)
                        {
                            if (!(p.x < 0) && !(p.y < 0))
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

                setFigureInArray(fig);
            }
        }


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

        
    }
}
