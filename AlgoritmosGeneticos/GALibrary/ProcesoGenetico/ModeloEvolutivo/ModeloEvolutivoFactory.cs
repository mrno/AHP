using System;
using System.Collections.Generic;
using System.Reflection;
using GALibrary.ProcesoGenetico.Mutadores;

namespace GALibrary.ProcesoGenetico.ModeloEvolutivo
{
    public class ModeloEvolutivoFactory
    {
        private Dictionary<string, Type> _evolutionModelTypes = new Dictionary<string, Type>();

        public ModeloEvolutivoFactory()
        {
            LoadEvolutionModelTypes();
        }

        public void LoadEvolutionModelTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(IModeloEvolutivo).ToString()) != null)
                {
                    _evolutionModelTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public IModeloEvolutivo CreateInstance(string evolutionModelTypeName)
        {
            var name = evolutionModelTypeName.ToLower();
            Type t = null;
            foreach (var modelType in _evolutionModelTypes)
            {
                if (modelType.Key.Contains(name))
                {
                    t = modelType.Value;
                    break;
                }
            }

            if (t == null)
                throw new ModeloEvolutivoCreationException("error - no se pudo crear el modelo evolutivo especificado");

            return Activator.CreateInstance(t) as IModeloEvolutivo;
        }
    }
}
