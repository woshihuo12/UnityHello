using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Excel;

//FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

////Choose one of either 1 or 2
////1. Reading from a binary Excel file ('97-2003 format; *.xls)
//IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

////2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
//IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

////Choose one of either 3, 4, or 5
////3. DataSet - The result of each spreadsheet will be created in the result.Tables
//DataSet result = excelReader.AsDataSet();

////4. DataSet - Create column names from first row
//excelReader.IsFirstRowAsColumnNames = true;
//DataSet result = excelReader.AsDataSet();

////5. Data Reader methods
//while (excelReader.Read())
//{
//    //excelReader.GetInt32(0);
//}

////6. Free resources (IExcelDataReader is IDisposable)
//excelReader.Close();


//int columns = result.Tables[0].Columns.Count;
//    int rows = result.Tables[0].Rows.Count;

//    for(int i = 0;  i< rows; i++)
//    {
//        for(int j =0; j < columns; j++)
//        {
//            string  nvalue  = result.Tables[0].Rows[i][j].ToString();
//            Debug.Log(nvalue);
//        }
//    }	


public class StringTableTool
{
    [MenuItem("CustomTool/StringTableTool")]
    static void ExportStringTable()
    {
        string filePath = Application.dataPath + "/Editor/Globalization/StringTable.xlsx";
        FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
        if (stream == null)
        {
            EditorUtility.DisplayDialog("StringTable", filePath + " 没有找到此文件", "OK");
            return;
        }

        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
        if (excelReader == null)
        {
            EditorUtility.DisplayDialog("StringTable", "请使用2007 xlsx格式", "OK");
            return;
        }

        excelReader.IsFirstRowAsColumnNames = false;
        System.Data.DataSet tmpDataSet = excelReader.AsDataSet(true);



        excelReader.Dispose();
        excelReader = null;
    }
}
