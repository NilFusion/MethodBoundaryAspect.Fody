﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.Shared.Attributes;

namespace MethodBoundaryAspect.Fody.UnitTests.Shared
{
    public class MethodBoundaryAspectTestBase : IDisposable
    {
        public MethodBoundaryAspectTestBase()
        {
            var url = Path.GetDirectoryName(GetType().Assembly.CodeBase);
            var path = url.Substring(@"file:\\".Length - 1);

            Environment.CurrentDirectory = path;
        }
        
        protected static string WeavedAssemblyPath { get; private set; }
        protected Type WeavedType { get; private set; }
        protected ModuleWeaver Weaver { get; set; }
        
        public virtual void Dispose()
        {
            TryCleanupWeavedAssembly();
        }

        private static void TryCleanupWeavedAssembly()
        {
            if (File.Exists(WeavedAssemblyPath))
                File.Delete(WeavedAssemblyPath);

            var pdbPath = Path.ChangeExtension(WeavedAssemblyPath, "pdb");
            if (File.Exists(pdbPath))
                File.Delete(pdbPath);
        }

        protected void WeaveAssemblyClass(Type type)
        {
            WeaveAssemblyAndVerify(type, null, null);
        }

        protected void WeaveAssemblyMethod(Type type, string methodName)
        {
            WeaveAssemblyAndVerify(type, methodName, null);
        }

        protected void WeaveAssemblyProperty(Type type, string propertyName)
        {
            WeaveAssemblyAndVerify(type, null, propertyName);
        }

        protected void RunIlSpy()
        {
            var originalPath = GetDllAssemblyPath();

            var methodName = Weaver?.MethodFilters.SingleOrDefault();
            if (methodName != null)
            {
                IlSpy.ShowMethod(methodName, WeavedAssemblyPath);
                IlSpy.ShowMethod(methodName, originalPath);
            }
            else
            {
                var typeName = Weaver?.TypeFilters.SingleOrDefault();
                if (typeName != null)
                {
                    IlSpy.ShowType(typeName, WeavedAssemblyPath);
                    IlSpy.ShowType(typeName, originalPath);
                }
                else
                    return;
            }

            // wait until ILSpy is started because weaved dll will be deleted when unittests exits -> TryCleanupWeavedFiles()
            var wait = TimeSpan.FromSeconds(2);
            Thread.Sleep(wait); 
        }

        protected void WeaveAssemblyAndVerify(Type type, string methodName, string propertyName)
        {
            WeavedType = type;
            Weaver = new ModuleWeaver();
            
            if (propertyName != null)
            {
                var fullPropertyName = CreateFullPropertyName(type, propertyName);
                Weaver.AddPropertyFilter(fullPropertyName.Item1);
                Weaver.AddPropertyFilter(fullPropertyName.Item2);
            }
            else if (methodName == null)
                Weaver.AddClassFilter(type.FullName);
            else
            {
                var fullMethodName = CreateFullMethodName(type, methodName);
                Weaver.AddMethodFilter(fullMethodName);
            }

            WeaveAssembly(type, Weaver);
            var ignores = type.Assembly.GetCustomAttributes<IgnorePEVerifyCode>();
            RunPeVerify(ignores.Select(a => a.ErrorCode));
        }

        private string GetDllAssemblyPath()
        {
            return WeavedType.Assembly.CodeBase.Replace(@"file:///", string.Empty);
        }

        private static void WeaveAssembly(Type type, ModuleWeaver weaver)
        {
            var normalizedPath = type.Assembly.CodeBase.Replace(@"file:///", string.Empty);
            WeavedAssemblyPath = weaver.WeaveToShadowFile(normalizedPath);
        }

        protected static string WeaveAssembly(Type assemblyType)
        {
            var normalizedPath = assemblyType.Assembly.CodeBase.Replace(@"file:///", string.Empty);

            var weaver = new ModuleWeaver();
            return WeavedAssemblyPath = weaver.WeaveToShadowFile(normalizedPath);
        }
        
        private string CreateFullMethodName(Type type, string methodName)
        {
            var methodInfo = type.GetMethod(methodName);
            if (methodInfo == null)
                throw new InvalidOperationException($"Method '{methodName}' not found in type '{type.FullName}'");

            return $"{type.FullName.Replace('+','/')}.{methodInfo.Name}";
        }

        private Tuple<string,string> CreateFullPropertyName(Type type, string propertyName)
        {
            var propertyInfo = type.GetProperty(propertyName);
            if (propertyInfo == null)
                throw new InvalidOperationException($"Property '{propertyName}' not found in type '{type.FullName}'");


            return new Tuple<string, string>(
                $"{type.FullName}.{propertyInfo.SetMethod.Name}",
                $"{type.FullName}.{propertyInfo.GetMethod.Name}");
        }

        private void RunPeVerify(IEnumerable<string> ignoreErrorCodes)
        {
            Action action = () =>
            {
                var runIlSpy = false;
                try
                {
                    PeVerifier.Verify(WeavedAssemblyPath, ignoreErrorCodes);
                }
                catch (Exception)
                {
                    runIlSpy = true;
                    throw;
                }
                finally
                {
                    if (runIlSpy|| IlSpy.AlwaysRunIlSpy)
                        RunIlSpy();
                }
                
            };
            action.Should().NotThrow();
        }
    }
}