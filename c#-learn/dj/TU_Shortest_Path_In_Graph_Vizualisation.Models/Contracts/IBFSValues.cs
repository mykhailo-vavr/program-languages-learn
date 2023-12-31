﻿namespace TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts
{
    public interface IBFSValues
    {
        bool IsVisited { get; set; }
        INode PreviousNode { get; set; }
        int DistanceFromSource { get; set; }

        void ResetParameters();
    }
}
