using System;
using System.Collections.Generic;
using System.Reflection;
using GALibrary.ProcesoGenetico.CondicionParada;

namespace GALibrary.ProcesoGenetico.ConvergenciaPoblacion
{
    public class ConvergenciaPoblacionFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public ConvergenciaPoblacionFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IConvergenciaPoblacion).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IConvergenciaPoblacion CreateInstance(string instanceName)
        {
            var name = instanceName.ToLower();
            Type t = null;
            foreach (var type in _types)
            {
                if (type.Key.Contains(name))
                {
                    t = type.Value;
                    break;
                }
            }
            
            try
            {
                return Activator.CreateInstance(t) as IConvergenciaPoblacion;
            }
            catch (Exception)
            {
                throw new ConvergenciaPoblacionCreationException("error - no se pudo crear la estrategia");
            }
        }
    }
}
