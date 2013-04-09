using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GALibrary.ProcesoGenetico.ModeloEvolutivo;
using GALibrary.ProcesoGenetico.Operadores.Abstracto;

namespace GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad
{
    public class ProbabilidadMutacionFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public ProbabilidadMutacionFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IProbabilidadMutacion).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IProbabilidadMutacion CreateInstance(string instanceName, object[] instanceParameters)
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
                return Activator.CreateInstance(t, instanceParameters) as IProbabilidadMutacion;
            }
            catch (Exception)
            {
                throw new ProbabilidadMutacionException(
                    "error - no se pudo crear la estrategia de probabilidad de mutación especificada");
            }
        }
    }
}
