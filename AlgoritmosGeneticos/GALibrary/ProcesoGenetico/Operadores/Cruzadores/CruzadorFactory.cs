using System;
using System.Collections.Generic;
using System.Reflection;
using GALibrary.ProcesoGenetico.ModeloEvolutivo;

namespace GALibrary.ProcesoGenetico.Cruzadores
{
    public class CruzadorFactory
    {
        private Dictionary<string, Type> _crossoverTypes = new Dictionary<string, Type>();

        public CruzadorFactory()
        {
            LoadCrossOverTypes();
        }

        public void LoadCrossOverTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(CruzadorAbstracto).ToString()) != null)
                {
                    _crossoverTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public CruzadorAbstracto CreateInstance(string evolutionModelTypeName)
        {
            var name = evolutionModelTypeName.ToLower();
            Type t = null;
            foreach (var modelType in _crossoverTypes)
            {
                if (modelType.Key.Contains(name))
                {
                    t = modelType.Value;
                    break;
                }
            }

            if (t == null)
                throw new CruzadorCreationException("error - no se pudo crear el modelo evolutivo especificado");

            return Activator.CreateInstance(t) as CruzadorAbstracto;
        }
    }
}
