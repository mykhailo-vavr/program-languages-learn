using System.Threading.Tasks;
using TU_Shortest_Path_In_Graph_BFS.Contracts;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_BFS
{
    public class Bfs : BFS
    {
        private const bool DEFAULT_DESTINATION_IS_VISITED = false;

        public Bfs(IGraph graph)
        {
            this.Graph = graph;
        }

        public INode CurrentNode { get; private set; }

        public bool DestinationIsVisited { get; private set; }

        public IGraph Graph { get; private set; }

        public Task Step0()
        {
            return Task.Run(() =>
            {
                this.DestinationIsVisited = DEFAULT_DESTINATION_IS_VISITED;
                this.CurrentNode = null;
            });
        }

        public Task Step1()
        {
            return Task.Run(() =>
            {
                foreach (INode node in this.Graph.Nodes)
                {
                    node.ResetParameters();
                }
            });
        }

        public Task Step2()
        {
            return Task.Run(() =>
            {
                this.Graph.Source.DistanceFromSource = 0;

                this.CurrentNode = this.Graph.Source;
            });
        }

        public Task Step3()
        {
            return Task.Run(() =>
            {
                foreach (ILink link in this.CurrentNode.ConnectedLinks)
                {
                    INode otherNode;
                    if (link.ConnectedNodes.Item1 == this.CurrentNode)
                    {
                        otherNode = link.ConnectedNodes.Item2;
                    }
                    else
                    {
                        otherNode = link.ConnectedNodes.Item1;
                    }

                    if (!otherNode.IsVisited)
                    {
                        int tentativeDistance = this.CurrentNode.DistanceFromSource + link.Weight;

                        if (tentativeDistance < otherNode.DistanceFromSource)
                        {
                            otherNode.DistanceFromSource = tentativeDistance;
                            otherNode.PreviousNode = this.CurrentNode;
                        }
                    }
                }
            });
        }

        public Task Step4()
        {
            return Task.Run(() =>
            {
                this.CurrentNode.IsVisited = true;
            });
        }

        public Task Step5()
        {
            return Task.Run(() =>
            {
            this.DestinationIsVisited = this.Graph.Destination.IsVisited;
            });
        }

        public bool Step6()
        {
            
            int distanceFromSource = int.MaxValue;

            bool anyNodeIsTaken = false;

            foreach (INode node in this.Graph.Nodes)
            {
                if (!node.IsVisited && distanceFromSource > node.DistanceFromSource)
                {
                    distanceFromSource = node.DistanceFromSource;
                    this.CurrentNode = node;

                    anyNodeIsTaken = true;
                }
            }

            return anyNodeIsTaken;
            
        }
    }
}
