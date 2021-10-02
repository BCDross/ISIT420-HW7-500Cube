using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AnalysisServices.AdomdClient;

namespace ISIT420_HW7_500Cube_WinForm
{
    class CubeData
    {
        public DataSet GetQueryOne()
        {
            string query = "SELECT {[Measures].[Orders Count]} ON COLUMNS, " +
                            "NON EMPTY ORDER(([Sales Person Table].[First Name].CHILDREN, [CD Table].[C Dname].CHILDREN, [CD Table].[List Price].CHILDREN), [Measures].[Orders Count], BDESC) ON ROWS " +
                            "FROM[Node Orders500T];";

            DataSet cubeData = new DataSet();

            AdomdDataAdapter myDataAdapter = new AdomdDataAdapter();

            string connString = @"Data Source=DAGDA;Catalog=ISIT420-HW7-500Cube";
            AdomdConnection conn = new AdomdConnection(connString);

            myDataAdapter.SelectCommand = new AdomdCommand(query, conn);

            try
            {
                myDataAdapter.Fill(cubeData, "CubeData1");
            }
            catch(Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return cubeData;
        }

        public DataSet GetQueryTwo()
        {
            string query = "SELECT NON EMPTY([CD Table].[List Price].CHILDREN, [Measures].[Orders Count]) ON COLUMNS, " +
                           "NON EMPTY ORDER(([Sales Person Table].[First Name].CHILDREN), [Measures].[Orders Count], BDESC) ON ROWS " +
                           "FROM[Node Orders500T];";

            DataSet cubeData = new DataSet();

            AdomdDataAdapter myDataAdapter = new AdomdDataAdapter();

            string connString = @"Data Source=DAGDA;Catalog=ISIT420-HW7-500Cube";
            AdomdConnection conn = new AdomdConnection(connString);

            myDataAdapter.SelectCommand = new AdomdCommand(query, conn);

            try
            {
                myDataAdapter.Fill(cubeData, "CubeData2");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return cubeData;
        }

        public DataSet GetQueryThree()
        {
            string query = "SELECT {[Measures].[Orders Count]} ON COLUMNS, " +
                           "NON EMPTY ORDER(([Sales Person Table - Store].[City].CHILDREN AS City, [Sales Person Table - Store].[Number Employees].CHILDREN AS NumberOfEmployees) , [Measures].[Orders Count], BDESC) ON ROWS " +
                           "FROM[Node Orders500T];";

            DataSet cubeData = new DataSet();

            AdomdDataAdapter myDataAdapter = new AdomdDataAdapter();

            string connString = @"Data Source=DAGDA;Catalog=ISIT420-HW7-500Cube";
            AdomdConnection conn = new AdomdConnection(connString);

            myDataAdapter.SelectCommand = new AdomdCommand(query, conn);

            try
            {
                myDataAdapter.Fill(cubeData, "CubeData3");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            return cubeData;
        }
    }
}
