using System.Threading.Tasks;
using MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly
{
    public class AsyncOverwrite
    {
        public static string TestReturnArg(string arg) => ReturnArg(arg).Result;

        [ReturnEverythingIsFine]
        public static Task<string> ReturnArg(string arg) => Task.FromResult(arg);
    }
}
