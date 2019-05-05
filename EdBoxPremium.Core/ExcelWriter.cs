using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using OfficeOpenXml;

namespace EdBoxPremium.Core
{
    public static class ExcelWriter
    {
        public static string GetFilePatientRecords(string fileName, List<RegistrationExcelRecords> dataRecords)
        {
            return GetRegistrationExcelRecordFile(fileName, new List<string[]>()
            {
                new[]
                {
                    "School", "Matric Number", "Full Name", "Sex", "Program", "Blood Group", "Phone", "Email"
                }
            }, dataRecords);
        }

        private static string GetRegistrationExcelRecordFile(string fileName, IReadOnlyList<string[]> headerRow,
            IEnumerable<RegistrationExcelRecords> excelRecords)
        {
            try
            {
                var exportFilename = $"{HostingEnvironment.ApplicationPhysicalPath}DataFiles\\{fileName}.xlsx";

                using (var excel = new ExcelPackage())
                {
                    var sheetName = $"{fileName.Split('_')[fileName.Split('_').Length -1]}".ToUpper();
                    excel.Workbook.Worksheets.Add(sheetName);

                    var headerRange = "A1:" + char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                    var worksheet = excel.Workbook.Worksheets[sheetName];
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                    worksheet.Cells[headerRange].Style.Font.Bold = true;

                    var excelDataRecords = excelRecords.Select(x => new object[]
                    {
                        x.School,
                        x.MatricNumber, x.FullName, x.Sex, x.Program, x.BloodGroup, x.Phone, x.Email
                    }).ToArray();

                    worksheet.Cells[headerRange].Style.Font.Bold = true;

                    worksheet.Cells[2, 1].LoadFromArrays(excelDataRecords);

                    var excelFile = new FileInfo(exportFilename);
                    excel.SaveAs(excelFile);
                }

                return exportFilename;
            }
            catch (Exception e)
            {
                ActivityLogger.Log(e);
                return null;
            }
        }

        public class RegistrationExcelRecords
        {
            public string School { get; set; }
            public string MatricNumber { get; set; }
            public string FullName { get; set; }
            public string Sex { get; set; }
            public string Program { get; set; }
            public string BloodGroup { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
        }
    }
}
