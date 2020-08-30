using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    interface Maze
    {
        void paint();
    }

    interface MazeBuilder
    {
        void buildRoad(int i, int j);
        void buildWall(int i, int j);
        void buildTreasure(int i, int j);
        Maze getMaze();
    }

    class RealMaze : Maze
    {
        #region Private Field
        private string[,] maze = null;
        #endregion Private Field

        public RealMaze(string[,] maze)
        {
            this.maze = maze;
        }

        void Maze.paint()
        {
            if (this.maze == null)
                return;

            for (int i = 0; i < this.maze.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < this.maze.GetLength(1); j++)
                {
                    row = row + this.maze[i, j];
                }
                System.Console.WriteLine(row);
            }
        }
    }

    class MazeDirector
    {
        #region Private Field
        private int[, ] mazeInfo;
        private MazeBuilder builder;
        #endregion Private Field

        public MazeDirector(int[,] maze, MazeBuilder builder)
        {
            this.mazeInfo = maze;
            this.builder = builder;
        }

        public Maze build()
        {
            for (int i = 0; i < mazeInfo.GetLength(0); i++)
            {
                for (int j = 0; j < mazeInfo.GetLength(1); j++)
                {
                    switch (mazeInfo[i, j])
                    {
                        case 0:
                            builder.buildRoad(i, j);
                            break;
                        case 1:
                            builder.buildWall(i, j);
                            break;
                        case 2:
                            builder.buildTreasure(i, j);
                            break;
                    }
                }
            }
            return builder.getMaze();
        }
    }

    public class PlainBuilder : MazeBuilder
    {
        #region Private Field
        private string[,] maze = null;
        #endregion Private Field

        public PlainBuilder(int i, int j)
        {
            this.maze = new string[i, j];
        }

        #region implement MazeBuilder
        void MazeBuilder.buildRoad(int i, int j)
        {
            maze[i, j] = "  ";
        }

        void MazeBuilder.buildWall(int i, int j)
        {
            maze[i, j] = "□";
        }

        void MazeBuilder.buildTreasure(int i, int j)
        {
            maze[i, j] = "* ";
        }

        Maze MazeBuilder.getMaze()
        {
            return new RealMaze(this.maze); 
        }
        #endregion implement MazeBuilder
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int[][] material = new int[7][7]
            int[,] material = 
            {
                { 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 0, 2, 1 },
                { 1, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 2, 1, 0, 1, 1 },
                { 1, 1, 0, 1, 0, 1, 1 },
                { 1, 0, 0, 2, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1 },
            };

            MazeDirector director = new MazeDirector(material, 
                                        new PlainBuilder(material.GetLength(0), material.GetLength(1)));
            director.build().paint();
            Console.ReadLine();
        }
    }
}
