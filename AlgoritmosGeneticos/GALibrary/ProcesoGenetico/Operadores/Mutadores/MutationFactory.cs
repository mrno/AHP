using System;
using System.Collections.Generic;
using System.Reflection;

namespace GALibrary.ProcesoGenetico.Mutadores
{
    public class MutationFactory
    {
        private Dictionary<string, Type> _mutationTypes = new Dictionary<string, Type>();

        public MutationFactory()
        {
            LoadMutationTypes();
        }

        public void LoadMutationTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(MutadorAbstracto).ToString()) != null)
                {
                    _mutationTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public MutadorAbstracto CreateInstance(string mutationTypeName)
        {
            var name = mutationTypeName.ToLower();
            Type t = null;
            foreach (var mutationType in _mutationTypes)
            {
                if (mutationType.Key.Contains(name))
                {
                    t = mutationType.Value;
                    break;
                }
            }

            if (t == null)
                throw new MutadorCreationException("error - no se pudo crear el mutador especificado");

            return Activator.CreateInstance(t) as MutadorAbstracto;
        }
    }
}
