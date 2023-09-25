using System.Threading.Tasks;
using TU_Shortest_Path_In_Graph_Vizualisation.Models.Contracts;

namespace TU_Shortest_Path_In_Graph_BFS.Contracts
{
    public interface BFS
    {
        INode CurrentNode { get; }
        bool DestinationIsVisited { get; }
        IGraph Graph { get; }

        Task Step0();
        Task Step1();
        Task Step2();
        Task Step3();
        Task Step4();
        Task Step5();
        bool Step6();
    }
}
