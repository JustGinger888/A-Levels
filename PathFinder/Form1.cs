///
/// Path Finder - An Implementation of the A* Algorithm for a 2D grid space.
/// 
/// (c) 24th November 2018 Kane Lean (Poole High School)
/// Code provided under GNUv3 Licensing. 
/// 

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PathFinder
{
    public partial class Form1 : Form
    {
        private GridSpace _selectedGridSquare = null;
        private GridSpace _location1 = null; // Used to represent the starting location
        private GridSpace _location2 = null; // Used to represent the ending location

        private string[,] matrix = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupGridSpaces();
        }

        /// <summary>
        /// Clears all the existing MazeSquares and creates new ones
        /// </summary>
        private void SetupGridSpaces()
        {
            matrix = LoadGridMap("grid-map.txt");

            pnlGridPanel.Controls.Clear(); // Clear the existing panel

            // Calculate how many squares are required to fit the panel, given the square dimentions
            int MazeSquaresHorizontal = pnlGridPanel.Width / GridSpace.GRID_SPACE_WIDTH;
            int MazeSquaresVertical = pnlGridPanel.Height / GridSpace.GRID_SPACE_HEIGHT;

            // Fill the panel with the number of required squares.
            for (int i = 0; i < MazeSquaresVertical - 1; i++)
            {
                for (int j = 0; j < MazeSquaresHorizontal - 1; j++)
                {
                    GridSpace newGridSpace = new GridSpace();
                    newGridSpace.BackColor = Color.White;

                    if (matrix[j, i] == "X") // In this implementation, "X" indicates an obstical for pathfinding purposes
                    {
                        newGridSpace.BackColor = Color.Black;
                    }
                    else if (matrix[j, i] == "G") // Just a demonstration of how we can flag other coloured gridspaces (that do nothing).
                    {
                        newGridSpace.BackColor = Color.Gold;
                    }

                    // These are the co-ordinates for the grid space
                    newGridSpace.GridX = j;
                    newGridSpace.GridY = i;

                    newGridSpace.Click += GridSpace_Click; // Used for determining which gridspace should be selected/deselected
                    newGridSpace.Location = new Point(j * newGridSpace.Width, i * newGridSpace.Height);
                    pnlGridPanel.Controls.Add(newGridSpace); // adds the gridspace to the panel
                }
            }
        }

        /// <summary>
        /// Quick and dirty map loader.
        /// This could easily be improved.
        /// </summary>
        private string[,] LoadGridMap(string mapLocation)
        {
            string[,] matrixLoaded = new string[pnlGridPanel.Width / GridSpace.GRID_SPACE_WIDTH, pnlGridPanel.Height / GridSpace.GRID_SPACE_HEIGHT];

            StreamReader reader = new StreamReader(mapLocation);

            int lineNumber = 0;

            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] parts = line.Split(',');

                for (int i = 0; i < parts.Length -1; i++)
                {
                    matrixLoaded[i, lineNumber] = parts[i];
                }

                lineNumber++;
            }

            reader.Close();

            return matrixLoaded;
        }

        /// <summary>
        /// This is called when any grid space is clicked (see SetupGridSpaces())
        /// </summary>
        /// <param name="sender">The GridSpace which was clicked</param>
        private void GridSpace_Click(object sender, EventArgs e)
        {
            if (_selectedGridSquare != null)
            {
                _selectedGridSquare.DeselectSpace();
            }

            _selectedGridSquare = (GridSpace)sender;
            _selectedGridSquare.SelectSpace();
        }

        /// <summary>
        /// Removes any colour information for all of the grid space panels
        /// </summary>
        private void ClearAllGridSpaceColours()
        {
            foreach (GridSpace square in pnlGridPanel.Controls)
            {
                square.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Enforces the selected location (if it exists) to become "location1" (used as the starting node)
        /// </summary>
        private void btnSetLocation1_Click(object sender, EventArgs e)
        {
            if (_location1 != null)
            {
                _location1.ResetSpace();
            }

            if (_selectedGridSquare != null)
            {
                _selectedGridSquare.BackColor = Color.Blue;
                _location1 = _selectedGridSquare;
            }
        }

        /// <summary>
        /// Enforces the selected location (if it exists) to become "location2" (used as the ending node)
        /// </summary>
        private void btnSetLocation2_Click(object sender, EventArgs e)
        {
            if (_location2 != null)
            {
                _location2.ResetSpace();
            }

            if (_selectedGridSquare != null)
            {
                _location2 = _selectedGridSquare;
                _selectedGridSquare.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Begins the A* pathfinding algorithm and arranges the output on the form
        /// </summary>
        private void btnFindPath_Generate(object sender, EventArgs e)
        {
            int startLocationX = _location1.GridX;
            int startLocationY = _location1.GridY;
            int endLocationX = _location2.GridX;
            int endLocationY = _location2.GridY;

            // This calls the A* Algorithm and returns the very last node (which is hopefully the endLocation node!)
            GridSpace endingGridSpace = FindPathUsingAStar(matrix, startLocationX, startLocationY, endLocationX, endLocationY);

            // This seciton of code creates the path between the start and the end by 'unwinding' the ParentSpace pointers
            Stack<GridSpace> pathFromStartToEnd = new Stack<GridSpace>();

            while (endingGridSpace.GridX != startLocationX || endingGridSpace.GridY != startLocationY)
            {
                pathFromStartToEnd.Push(endingGridSpace);
                endingGridSpace = endingGridSpace.ParentSpace;
            }

            pathFromStartToEnd.Push(endingGridSpace);

            // We're all done, this section of code just updates the interface with the path that was found
            lstRouteFound.Items.Clear();

            while (pathFromStartToEnd.Count > 0)
            {
                GridSpace gridSpaceRouteItem = pathFromStartToEnd.Pop();
                gridSpaceRouteItem.HighlightSpace();

                lstRouteFound.Items.Add("(" + gridSpaceRouteItem.GridX + "," + gridSpaceRouteItem.GridY + ")");
            }
        }

        /// <summary>
        /// Helper method to get a specific GridSpace object from the form panel, given an x and y co-ordinate.
        /// </summary>
        public GridSpace GetGridSpaceGivenXandY(int x, int y)
        {
            GridSpace gridSpaceOnForm = (GridSpace)pnlGridPanel.GetChildAtPoint(new Point(x * GridSpace.GRID_SPACE_HEIGHT, y * GridSpace.GRID_SPACE_WIDTH));
            return gridSpaceOnForm;
        }

        /// <summary>
        /// Finds the smallest SumWight from the Dictionary of provided grid spaces.
        /// Called as part of the main A* algorithm
        /// </summary>
        private KeyValuePair<string, GridSpace> FindSmallestWeighting(Dictionary<string, GridSpace> gridSpaceList)
        {
            KeyValuePair<string, GridSpace> smallestWeighted = gridSpaceList.ElementAt(0);

            foreach (KeyValuePair<string, GridSpace> item in gridSpaceList)
            {
                if (item.Value.SumWeight < smallestWeighted.Value.SumWeight)
                {
                    smallestWeighted = item;
                }
                else if ((item.Value.SumWeight == smallestWeighted.Value.SumWeight) && (item.Value.ToWeighting < smallestWeighted.Value.ToWeighting))
                {
                    smallestWeighted = item;
                }
            }

            return smallestWeighted;
        }

        /// <summary>
        /// An implementation of the A* pathfinding algorithm.
        /// Source code adapted from https://stackoverflow.com/questions/2138642/how-to-implement-an-a-algorithm
        /// </summary>
        private GridSpace FindPathUsingAStar(string[,] matrix, int fromX, int fromY, int toX, int toY)
        {
            Dictionary<string, GridSpace> unvisitedNodes = new Dictionary<string, GridSpace>(); 
            Dictionary<string, GridSpace> visitedNode = new Dictionary<string, GridSpace>();

            // Find the required GridSpace object from the 2D panel
            GridSpace startNode = GetGridSpaceGivenXandY(fromX, fromY); 

            string key = startNode.GridX.ToString() + startNode.GridX.ToString();
            unvisitedNodes.Add(key, startNode);

            // These are the values that will be added to the current GridSpace X and Y co-ordinates
            // this will then mean we can find the co-ordinates of the current GridSpaces's neighbours
            // IF YOU NEED DIAGONAL MOVES, THIS IS WHERE THEY WOULD BE ADDED (Add more neighbours to the list below, [1,1] [-1,-1], [1,-1] -[1,1] etc)
            // (Added an example - see the IF statement immediately after these 5 statements)
            List<KeyValuePair<int, int>> neighbours = new List<KeyValuePair<int, int>>();
            neighbours.Add(new KeyValuePair<int, int>(-1, 0));
            neighbours.Add(new KeyValuePair<int, int>(0, 1));
            neighbours.Add(new KeyValuePair<int, int>(1, 0));
            neighbours.Add(new KeyValuePair<int, int>(0, -1));

            // Ok I added a demonstration...!
            if (cbxDiagonalMode.Checked)
            {
                neighbours.Add(new KeyValuePair<int, int>(1, 1));
                neighbours.Add(new KeyValuePair<int, int>(1, -1));
                neighbours.Add(new KeyValuePair<int, int>(-1, 1));
                neighbours.Add(new KeyValuePair<int, int>(-1, -1));
            }

            int maxX = matrix.GetLength(0) -1;
            int maxY = matrix.GetLength(1) -1;

            if (maxX == 0)
            { 
                return null;
            }

            while (true)  
            {
                if (unvisitedNodes.Count == 0)
                {
                    return null;
                }

                KeyValuePair<string, GridSpace> current = FindSmallestWeighting(unvisitedNodes);

                // This will exit the indefinite while loop once we find our destination GridSpace
                if (current.Value.GridX == toX && current.Value.GridY == toY)
                {
                    return current.Value;
                }

                unvisitedNodes.Remove(current.Key);
                visitedNode.Add(current.Key, current.Value);

                // Check the weightings of all the neighbours to see which is best to visit next
                foreach (KeyValuePair<int, int> plusXY in neighbours)
                {
                    int nextX = current.Value.GridX + plusXY.Key;
                    int nextY = current.Value.GridY + plusXY.Value;
                    string nextWeighting = nextX.ToString() + nextY.ToString();

                    // The character 'X' indicates an obstacle
                    if (nextX < 0 || nextY < 0 || nextX >= maxX || nextY >= maxY || visitedNode.ContainsKey(nextWeighting) || matrix[nextX,nextY] == "X")
                    {
                        continue; // No need to visit this node - skip this iteration to check the next GridSpace
                    }

                    if (unvisitedNodes.ContainsKey(nextWeighting))
                    {
                        GridSpace currentSpace = unvisitedNodes[nextWeighting];
                        int from = Math.Abs(nextX - fromX) + Math.Abs(nextY - fromY);

                        if (from < currentSpace.FromWeighting)
                        {
                            currentSpace.FromWeighting = from;
                            currentSpace.SumWeight = currentSpace.FromWeighting + currentSpace.ToWeighting;
                            currentSpace.ParentSpace = current.Value;
                        }
                    }
                    else 
                    {
                        // Find the required GridSpace object from the 2D panel
                        GridSpace currentSpace = GetGridSpaceGivenXandY(nextX, nextY);

                        // ABS as we don't want negative weights
                        currentSpace.FromWeighting = Math.Abs(nextX - fromX) + Math.Abs(nextY - fromY);
                        currentSpace.ToWeighting = Math.Abs(nextX - toX) + Math.Abs(nextY - toY);
                        currentSpace.SumWeight = currentSpace.FromWeighting + currentSpace.ToWeighting;
                        currentSpace.ParentSpace = current.Value;
                        unvisitedNodes.Add(nextWeighting, currentSpace);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllGridSpaceColours();
            SetupGridSpaces();
        }
    }
}
