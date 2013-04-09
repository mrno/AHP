using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GALibrary.ProcesoGenetico.Operadores.Mutadores.Probabilidad;

namespace GALibrary.ProcesoGenetico.CondicionParada
{
    public class CondicionParadaFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public CondicionParadaFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(ICondicionParada).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public ICondicionParada CreateInstance(string instanceName, object[] instanceParameters)
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
                return Activator.CreateInstance(t, instanceParameters) as ICondicionParada;
            }
            catch (Exception)
            {
                throw new CondicionParadaCreationException("error - no se pudo crear la estrategia");
            }
        }
    }
}
