using System.Collections.Generic;
using System.Linq;
public  class GenerateSqlQuery
{


    public  string InsertQuery(List<string> InputData, string SelectTable)
    {
        string InserQuery = $"insert into {SelectTable} VALUES ( ";
        for (int i = 0; i < InputData.Count(); i++)
        {
            InserQuery += $" N'{InputData[i]}' ";
            if (i + 1 < InputData.Count())
            {
                InserQuery += " , ";
            }
        }
        InserQuery += " ); ";
        return InserQuery;
    }




    public  string UpdateQuery(List<string> InputData, List<string> ColumnsName , string SelectTable)
    {
        string UpdateQuery = $"update {SelectTable} set";
        for (int i = 0; i < ColumnsName.Count(); i++)
        {
            UpdateQuery += $" {ColumnsName[i]} = N'{InputData[i]}' ";
            if (i + 1 < InputData.Count)
            {
                UpdateQuery += " , ";
            }
        }
        UpdateQuery += $" where {ColumnsName[0]} = N'{InputData[0]}' ; ";
        return UpdateQuery;
    }


    public  string SearchQuery(string SearchText, List<string> ColumnsName, string SelectTable)
    {
        string SearchQuery = $"select * from {SelectTable} where ";
        for (int i = 0; i < ColumnsName.Count(); i++)
        {
            SearchQuery += $" {ColumnsName[i]} Like N'%{SearchText}%' ";
            if (i + 1 < ColumnsName.Count)
            {
                SearchQuery += " or ";
            }
        }
        SearchQuery += $";";
        return SearchQuery;
    }



    public  string  DeleteQuery(List<string> InputData, List<string> ColumnsName, string SelectTable)
    {
        return $"delete from {SelectTable} where {ColumnsName[0]} = N'{InputData[0]}' ;";
    }



}

