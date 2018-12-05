using MethodBoundaryAspect.Fody.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461.TestAssembly.Aspects
{
    public class SecondAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs arg)
        {
            MultipleAspectsMethods.Result += "[SecondAspect_OnEntry]";
            arg.MethodExecutionTag = "[SecondAspect_OnExit]";
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            MultipleAspectsMethods.Result += arg.MethodExecutionTag;
        }
    }
}