using System;
using System.Collections.Generic;
using System.Reflection;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public ModeloEvolutivoFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IModeloEvolutivo).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IModeloEvolutivo CreateInstance(string instanceName)
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
                throw new ModeloEvolutivoCreationException("error - no se pudo crear el modelo evolutivo especificado");

            return Activator.CreateInstance(t) as IModeloEvolutivo;
        }
    }
}
