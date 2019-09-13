using System;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ColorRevitAddIn
{
    [Transaction(TransactionMode.Manual)]
    public class ColorRomCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var document = commandData.Application.ActiveUIDocument.Document;
            var transaction = new Transaction(document, "ColorRom");
            transaction.Start();
            try
            {
                var building = new Building();
                var parts = new PartElements(document).Find().Select(element => new Part(element));
                building.Add(parts);
                building.Process();

                transaction.Commit();
                return Result.Succeeded;
            }
            catch (OperationCanceledException)
            {
                transaction.RollBack();
                return Result.Cancelled;
            }
            catch (Exception e)
            {
                message = e.Message;
                transaction.RollBack();
                return Result.Failed;
            }
        }
    }
}