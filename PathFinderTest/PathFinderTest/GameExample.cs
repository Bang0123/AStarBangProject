using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PathFinderTest
{
    public class GameExample
    {
        private const int Length = 12;
        private const int Height = 8;
        private Gameboard Gameboard { get; }
        //private static readonly Node StartPoint = new Node(2, 2);
        //private static readonly Node EndPoint = new Node(6, 8);
        //private static readonly List<Node> Walls = new List<Node>() { new Node(4, 6), new Node(3, 6), new Node(4, 5), new Node(2, 6) };
        private static readonly Node StartPoint = new Node(1, 11);
        private static readonly Node EndPoint = new Node(6, 2);
        private static readonly List<Node> Walls = new List<Node>() { new Node(4, 2), new Node(4, 1), new Node(4, 0), new Node(4, 3), new Node(4, 4), new Node(4, 5), new Node(4, 6), new Node(4, 7), new Node(4, 8), new Node(4, 9) };

        /// <summary>
        /// Constructor for the Example
        /// </summary>
        public GameExample()
        {
            var nodeMap = GetNodeMap(Height, Length);
            Gameboard = new Gameboard(nodeMap, StartPoint, EndPoint, Walls);
            var pathfinder = new PathFinder(Gameboard);
            pathfinder.FindAStarPath();
        }

        /// <summary>
        /// Get a nodemap of height and length
        /// </summary>
        /// <param name="height"></param>
        /// <param name="length"></param>
        /// <returns>2d node map with printstate path</returns>
        private static Node[,] GetNodeMap(int height, int length)
        {
            var nodeMap = new Node[height, length];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    nodeMap[i, j] = new Node(i, j) { PrintState = NodeState.Path };
                }
            }
            return nodeMap;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Length; j++)
                {
                    if (Gameboard.NodeMap[i, j].PrintState == NodeState.Path) stringBuilder.Append((char)183);
                    if (Gameboard.NodeMap[i, j].PrintState == NodeState.Wall) stringBuilder.Append((char)219);
                    if (Gameboard.NodeMap[i, j].PrintState == NodeState.Start) stringBuilder.Append("S");
                    if (Gameboard.NodeMap[i, j].PrintState == NodeState.End) stringBuilder.Append("E");
                    if (Gameboard.NodeMap[i, j].PrintState == NodeState.Walked) stringBuilder.Append("W");
                }
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }
    }
}
