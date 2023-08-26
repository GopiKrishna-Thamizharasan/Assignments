using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace Assignment1
{
    [Transaction(TransactionMode.Manual)]
    public class Textboxdisplay : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            Result result = Result.Succeeded;
            TaskDialog dialog = new TaskDialog("Hello Revit");
            dialog.FooterText = "Click her for Revit API Development Centre";
            dialog.MainContent = "This Sample shows how to use a Revit task dialog to communicate with the user." +
                "The command links below open additional task dialogs with more information";
            dialog.MainInstruction = "Hello, Revit!";
            dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, 
                "View Information about Revit installation");
            dialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, 
                "View Information about the active document");
            dialog.CommonButtons = TaskDialogCommonButtons.Close;
            
            dialog.Show();

            TaskDialogResult clickresult = dialog.Show();

            if (TaskDialogResult.CommandLink1 == clickresult)
            {
                TaskDialog commandlink1display = new TaskDialog("Information about Revit Installation");
                commandlink1display.MainInstruction = "Installation Information";
                commandlink1display.MainContent = $"Version = 2024 \n Software name = Autodesk Revit";
                commandlink1display.Show();
            }
            else if (TaskDialogResult.CommandLink2 == clickresult)
            {
                TaskDialog commandlink1display = new TaskDialog("View Information about the active document");
                commandlink1display.MainInstruction = "Document Information";
                commandlink1display.MainContent = $"{doc}";
                commandlink1display.Show();
            }



            return result;

        }
    }
}
