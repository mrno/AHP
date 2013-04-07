using System;
using System.Collections.Generic;
using System.Reflection;

namespace GALibrary.ProcesoGenetico.Operadores.Abstracto
{
    public class OperadorFactory
    {
        private Dictionary<string, Type> _operatorTypes = new Dictionary<string, Type>();

        public OperadorFactory()
        {
            LoadOperatorTypes();
        }

        public void LoadOperatorTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IOperador).ToString()) != null)
                {
                    _operatorTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IOperador CreateInstance(string operatorTypeName)
        {
            var name = operatorTypeName.ToLower();
            Type t = null;
            foreach (var operatorType in _operatorTypes)
            {
                if (operatorType.Key.Contains(name))
                {
                    t = operatorType.Value;
                    break;
                }
            }

            if (t == null)
                throw new OperadorCreationException("error - no se pudo crear el operador especificado");

            return Activator.CreateInstance(t) as IOperador;
        }
    }
}
