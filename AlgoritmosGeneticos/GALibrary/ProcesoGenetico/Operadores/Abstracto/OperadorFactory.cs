using System;
using System.Collections.Generic;
using System.Reflection;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public class OperadorFactory
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public OperadorFactory()
        {
            LoadTypes();
        }

        public void LoadTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IOperador).ToString()) != null)
                {
                    _types.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IOperador CreateInstance(string instanceName)
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
                throw new OperadorCreationException("error - no se pudo crear el operador especificado");

            return Activator.CreateInstance(t) as IOperador;
        }
    }
}
