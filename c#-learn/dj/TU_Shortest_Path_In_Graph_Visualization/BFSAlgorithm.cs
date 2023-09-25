using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TU_Shortest_Path_In_Graph_BFS;
using TU_Shortest_Path_In_Graph_BFS.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing;
using TU_Shortest_Path_In_Graph_Vizualisation.Drawing.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_Visualization
{
    public partial class BFSAlgorithm : Form
    {
        private const int DEFAULT_CURRENT_STEP = 0;
        private const bool DEFAULT_IS_FINISHED = false;
        private const bool DEFAULT_IS_REACHABLE = false;
        private const int MAX_UN_VISITED_NODES_TEXT = 14;

        private static readonly string[] stepText = new string[] { " Step 1: Set all nodes as unvisited. Set the distance to the source of all nodes to infinity. Set previous node of all nodes to null.", "Step 2: Set the distance to source of the source node to 0. Set the source node as current node", "Step 3: For the current node, consider all of its unvisited neighbours and calculate their tentative distances through the current node.\nCompare the newly calculated tentative distance to the current assigned value and assign the smaller one.\nIf a new value is assigned change previous node to the current node.", "Step 4: Set the current node as visited and remove it from the unvisited list. A visited node will never be checked again." , "Step 5: If the destination node has been set to visited than stop the algorithm." , "Step 6: Otherwise, select the unvisited node that is marked with the smallest tentative distance, set it as the new current node, \nand go back to step 3. if no such node exists and destination has not been reached than stop the algorithm with no results." , "Final Step: After the end trace back through the previous nodes starting from the destination and ending with the source. \nThat is your shortest path.", "Final Step: Destination is not reachable." };

        private readonly BFS bfs;
        private int currentStep;
        private bool isFinished;
        private bool isReachable;

        public BFSAlgorithm(IGraph graph)
        {
            InitializeComponent();

            this.bfs = new Bfs(graph);

            this.currentStep = DEFAULT_CURRENT_STEP;
            this.isFinished = DEFAULT_IS_FINISHED;
            this.isReachable = DEFAULT_IS_REACHABLE;

            this.bfs.Step0();
        }

        //Draws all the links, then draws all the nodes, then draws tenative values if the current step is one or more. 
        public void DrawPanel(Graphics graphics)
        {
            foreach (INode node in this.bfs.Graph.Nodes.OrderBy(n => n.Layer))
            {
                foreach (ILink link in node.ConnectedLinks)
                {
                    ILinkDraw linkDraw = new LinkDraw(link);

                    linkDraw.Draw(graphics, Color.Black);
                }
            }

            foreach (INode node in this.bfs.Graph.Nodes.OrderBy(n => n.Layer))
            {
                INodeDraw nodeDraw = new NodeDraw(node);

                if (this.bfs.CurrentNode == node)
                {
                    nodeDraw.Draw(graphics, Color.Red);
                }
                else if (node == this.bfs.Graph.Source)
                {
                    nodeDraw.Draw(graphics, Color.Blue);
                }
                else if (node == this.bfs.Graph.Destination)
                {
                    nodeDraw.Draw(graphics, Color.Green);
                }
                else
                {
                    nodeDraw.Draw(graphics, Color.Black);
                }

                if(this.currentStep >= 1)
                {
                    nodeDraw.DrawTenativeValue(graphics, Color.Magenta);
                }
            }
        }
        
        
        private void NextStepButton_Click(object sender, System.EventArgs e)
        {
            if (!this.isFinished)
            {
                this.currentStep += 1;

                if (this.currentStep == 1)
                {
                    this.bfs.Step1();

                    this.Visualization.Refresh();
                }
                else if (this.currentStep == 2)
                {
                    this.bfs.Step2();

                    this.CurrentNodeLabel.Text = $"Current Node: {this.bfs.CurrentNode.NodeNumber}";

                    this.Visualization.Refresh();
                }
                else if (this.currentStep == 3)
                {
                    this.bfs.Step3();

                    this.Visualization.Refresh();

                }
                else if (this.currentStep == 4)
                {
                    this.bfs.Step4();

                }
                else if (this.currentStep == 5)
                {
                    this.bfs.Step5();

                    if (this.bfs.DestinationIsVisited)
                    {
                        this.isFinished = true;
                    }
                }
                else if (this.currentStep == 6)
                {
                    this.isReachable = this.bfs.Step6();

                    if (!this.isReachable)
                    {
                        this.isFinished = true;
                    }

                    this.CurrentNodeLabel.Text = $"Current Node: {this.bfs.CurrentNode.NodeNumber}";

                    this.Visualization.Refresh();

                    this.currentStep = 2;
                }
            }
            else
            {
                if (this.isReachable)
                {
                    this.ShortestPathLabel.Text = GetShortestPath();
                }
            }
        }

        //Navigates through all previous nodes starting from the destination and ending with source and then reverses the path
        private string GetShortestPath()
        {
            INode previousNode = this.bfs.CurrentNode;

            Stack<string> nodes = new Stack<string>();

            while (previousNode != null)
            {
                nodes.Push(previousNode.NodeNumber.ToString());
                previousNode = previousNode.PreviousNode;
            }

            StringBuilder stringBuilder = new StringBuilder(nodes.Pop());

            while(nodes.Count != 0)
            {
                stringBuilder.Append($" -> {nodes.Pop()}");
            }

            return stringBuilder.ToString();
        }
        
        //Disposes of the form itself
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        

        //Draws the Panel
        private void Visualization_Paint(object sender, PaintEventArgs e)
        {
            DrawPanel(e.Graphics);
        }
    }
}
