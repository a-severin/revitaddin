using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace ColorRevitAddIn
{
    public sealed class PartElements
    {
        private readonly Document _document;

        public PartElements(Document document)
        {
            _document = document;
        }

        public IEnumerable<Element> Find()
        {
            var collector = new FilteredElementCollector(_document);

            var filterStringRule = new FilterStringRule(
                new ParameterValueProvider(new ElementId(10616104)),
                new FilterStringContains(),
                "Квартира",
                false);
            var parameterFilter = new ElementParameterFilter(filterStringRule);

            var list = collector.WherePasses(new RoomFilter()).WherePasses(parameterFilter).ToElements();

            return list;
        }
    }
}