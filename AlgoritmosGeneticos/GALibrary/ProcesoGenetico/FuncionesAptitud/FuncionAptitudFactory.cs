using System;
using System.Collections.Generic;
using System.Reflection;
using GALibrary.ProcesoGenetico.ModeloEvolutivo;

namespace GALibrary.ProcesoGenetico.FuncionesAptitud
{
    public class FuncionAptitudFactory
    {
        private Dictionary<string, Type> _fitnessFunctionTypes = new Dictionary<string, Type>();

        public FuncionAptitudFactory()
        {
            LoadFitnessFunctionTypes();
        }

        public void LoadFitnessFunctionTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IFuncionAptitud).ToString()) != null)
                {
                    _fitnessFunctionTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IFuncionAptitud CreateInstance(string fitnessFunctionTypeName)
        {
            var name = fitnessFunctionTypeName.ToLower();
            Type t = null;
            foreach (var type in _fitnessFunctionTypes)
            {
                if (type.Key.Contains(name))
                {
                    t = type.Value;
                    break;
                }
            }

            if (t == null)
                throw new FuncionAptitudCreationException("error - no se pudo crear la funcion de aptitud especificada");

            return Activator.CreateInstance(t) as IFuncionAptitud;
        }
    }
}
