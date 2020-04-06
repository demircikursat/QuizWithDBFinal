using Project.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.SingletonPattern
{
    public class DBTool
    {


        DBTool() { }
        private static QuizContext _dbInstance;
        public static QuizContext DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new QuizContext();
                }
                return _dbInstance;
            }
        }



    }
}
