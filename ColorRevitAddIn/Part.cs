using System.Linq;
using Autodesk.Revit.DB;

namespace ColorRevitAddIn
{
    public sealed class Part : IPart
    {
        private readonly Element _element;

        public Part(Element element)
        {
            _element = element;
            Zone = element.GetParameters("ROM_Зона").FirstOrDefault()?.AsString();
            Subzone = element.GetParameters("ROM_Подзона").FirstOrDefault()?.AsString();
            Level = element.get_Parameter(BuiltInParameter.LEVEL_NAME).AsString();
            Block = element.GetParameters("BS_Блок").FirstOrDefault()?.AsString();
        }

        public string Block { get; }

        public string Level { get; }

        public string Subzone { get; }

        public string Zone { get; }

        public void SetSemitone()
        {
            var tone = _element.GetParameters("ROM_Расчетная_подзона_ID").First().AsString();
            _element.GetParameters("ROM_Подзона_Index").First().Set($"{tone}.Полутон");
        }
    }
}