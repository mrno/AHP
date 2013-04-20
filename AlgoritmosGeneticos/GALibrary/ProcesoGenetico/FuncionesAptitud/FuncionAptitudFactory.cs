using System;
using System.Collections.Generic;
using System.Reflection;
using GALibrary.ProcesoGenetico.ModeloEvolutivo;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public class FuncionAptitudFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public FuncionAptitudFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IFuncionAptitud).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IFuncionAptitud CreateInstance(string instanceName)
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

            if (t == null)
                throw new FuncionAptitudCreationException("error - no se pudo crear la estrategia");

            return Activator.CreateInstance(t) as IFuncionAptitud;
        }
    }
}
