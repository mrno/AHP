using System;
using System.Collections.Generic;
using System.Reflection;

namespace GALibrary.ProcesoGenetico.Selectores
{
    public class SelectorFactory
    {
        private Dictionary<string, Type> _seleccionTypes = new Dictionary<string, Type>();

        public SelectorFactory()
        {
            LoadSeleccionTypes();
        }

        public void LoadSeleccionTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if(type.GetInterface(typeof(SelectorAbstracto).ToString()) != null)
                {
                    _seleccionTypes.Add(type.Name.ToLower(), type);
                }
            }
        }

        public SelectorAbstracto CreateInstance(string seleccionTypeName)
        {
            var name = seleccionTypeName.ToLower();
            Type t = null;
            foreach (var seleccionType in _seleccionTypes)
            {
                if (seleccionType.Key.Contains(name))
                {
                    t = seleccionType.Value;
                    break;
                }
            }

            if (t == null)
                throw new SelectorCreationException("error se pudo crear el seleccionador deseado");

            return Activator.CreateInstance(t) as SelectorAbstracto;
        }
    }
}
