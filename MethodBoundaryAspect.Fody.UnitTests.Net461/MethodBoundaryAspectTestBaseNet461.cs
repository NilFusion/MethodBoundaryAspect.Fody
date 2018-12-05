using System;
using MethodBoundaryAspect.Fody.UnitTests.Shared;

namespace MethodBoundaryAspect.Fody.UnitTests.Net461
{
    public abstract class MethodBoundaryAspectTestBaseNet461 : MethodBoundaryAspectTestBase
    {
        private TestDomain _testDomain;
        
        protected AssemblyLoader AssemblyLoader { get; private set; }
        
        public override void Dispose()
        {
            AssemblyLoader = null;

            if (_testDomain != null)
            {
                _testDomain.Dispose();
                _testDomain = null;
            }

            base.Dispose();
        }

        protected void WeaveAssemblyClassAndLoad(Type type)
        {
            WeaveAssemblyAndVerifyAndLoad(type, null, null);
        }

        protected void WeaveAssemblyMethodAndLoad(Type type, string methodName)
        {
            WeaveAssemblyAndVerifyAndLoad(type, methodName, null);
        }

        protected void WeaveAssemblyPropertyAndLoad(Type type, string propertyName)
        {
            WeaveAssemblyAndVerifyAndLoad(type, null, propertyName);
        }
        
        private void WeaveAssemblyAndVerifyAndLoad(Type type, string methodName, string propertyName)
        {
            WeaveAssemblyAndVerify(type, methodName, propertyName);

            LoadWeavedAssembly();
        }

        private void LoadWeavedAssembly()
        {
            _testDomain = new TestDomain();

            AssemblyLoader = _testDomain.CreateAssemblyLoader();
            AssemblyLoader.SetDomain(_testDomain.AppDomain);
            AssemblyLoader.Load(WeavedAssemblyPath);
        }
    }
}