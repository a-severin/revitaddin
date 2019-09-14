using System;
using System.Linq;
using Autodesk.Revit.DB;

namespace ColorRevitAddIn
{
    public sealed class Part : IPart
    {
        private const string RomЗона = "ROM_Зона";
        private const string RomПодзона = "ROM_Подзона";
        private const string BsБлок = "BS_Блок";
        private const string RomРасчетнаяПодзонаId = "ROM_Расчетная_подзона_ID";
        private const string RomПодзонаIndex = "ROM_Подзона_Index";
        private readonly Element _element;

        public Part(Element element)
        {
            _element = element;
            Zone = element.GetParameters(RomЗона).FirstOrDefault()?.AsString();
            Subzone = element.GetParameters(RomПодзона).FirstOrDefault()?.AsString();
            Level = element.get_Parameter(BuiltInParameter.LEVEL_NAME).AsString();
            Block = element.GetParameters(BsБлок).FirstOrDefault()?.AsString();
        }

        public string Block { get; }

        public string Level { get; }

        public string Subzone { get; }

        public string Zone { get; }

        public void SetSemitone()
        {
            var calculatedIndexParameter = _element.GetParameters(RomРасчетнаяПодзонаId).FirstOrDefault();
            if (calculatedIndexParameter == null)
            {
                throw new SetSemitoneException($"{_element.Name} не содержит параметра '{RomРасчетнаяПодзонаId}'");
            }

            var tone = calculatedIndexParameter.AsString();

            var indexParameters = _element.GetParameters(RomПодзонаIndex);
            if (indexParameters.Count == 0)
            {
                throw new SetSemitoneException($"{_element.Name} не содержит параметра '{RomПодзонаIndex}'");
            }

            var value = $"{tone}.Полутон";

            try
            {
                indexParameters.First().Set(value);
            }
            catch (Exception e)
            {
                throw new SetSemitoneException(
                    $"Не удалось установить значение параметра '{RomПодзонаIndex}' для элемента '{_element.Name}' равным '{value}'",
                    e);
            }
        }
    }
}