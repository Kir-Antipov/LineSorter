using System;
using System.IO;
using System.Linq;
using LineSorter.Export;
using System.Reflection;
using System.Collections.Generic;

namespace LineSorter.Helpers
{
    // TODO: Separate AppDomains for different Assemblies
    public static class AssemblyLoader
    {
        #region Var
        //private static List<AppDomain> Domains { get; }
        private static Dictionary<string, Assembly> Assemblies { get; }
        #endregion

        #region Init
        static AssemblyLoader()
        {
            //Domains = new List<AppDomain>();
            Assemblies = new Dictionary<string, Assembly>();
        }
        #endregion

        #region Functions
        public static Assembly Load(string Path)
        {
            string key = Path.ToUpper();
            if (Assemblies.ContainsKey(key))
                return Assemblies[key];
            else
            {
                Assembly asm = Assembly.Load(File.ReadAllBytes(Path));
                Assemblies.Add(key, asm);
                //Domains.Add(dom);
                return asm;
            }
        }
        public static T LoadInterface<T>(this Assembly Assembly)
        {
            Type interfaceType = Assembly.DefinedTypes.FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(T)))?.AsType();
            return interfaceType == null ? default(T) : (T)Activator.CreateInstance(interfaceType);
        }
        public static IEnumerable<T> LoadInterfaces<T>(this Assembly Assembly)
        {
            foreach (Type type in Assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(T))).Select(x => x.AsType()))
                yield return (T)Activator.CreateInstance(type);
        }

        private static AppDomain CreateDomain(string Name)
        {
            AppDomain domain = AppDomain.CreateDomain(Name, AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = Commands.CommandUserSort.SavePath });
            domain.CreateInstanceAndUnwrap(typeof(Row).Assembly.FullName, typeof(Row).FullName);
            return domain;         
        }

        public static bool Unload(string Path)
        {
            /*Path = Path.ToUpper();
            if (Assemblies.ContainsKey(Path))
            {
                Assembly asm = Assemblies[Path];
                Assemblies.Remove(Path);
                AppDomain dom = Domains.First(x => x.FriendlyName == Path);
                Domains.Remove(dom);
                AppDomain.Unload(dom);
                new System.Runtime.InteropServices.RegistrationServices().UnregisterAssembly(asm);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                return true;
            }*/
            return false;
        }
        public static bool Unload(Func<AppDomain, bool> Matcher)
        {
            /*AppDomain dom = Domains.FirstOrDefault(Matcher);
            if (dom != null)
            {
                Assembly[] asms = dom.GetAssemblies();
                string path = Assemblies.FirstOrDefault(x => asms.Contains(x.Value)).Key;
                new System.Runtime.InteropServices.RegistrationServices().UnregisterAssembly(Assemblies[path]);
                Assemblies.Remove(path);
                AppDomain.Unload(dom);
                Domains.Remove(dom);
                return true;
            }*/
            return false;
        }
        public static bool Unload(Assembly Assembly) => Unload(Assembly.Location) || Unload(x => x.GetAssemblies().Contains(Assembly));
        #endregion
    }
}
