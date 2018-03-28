using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingTest
{
    public class SaveDataList : List<StudentAnswers>
    {
        //constructors to expose the underlying list consctuctors
        public SaveDataList(int capacity) : base(capacity)
        {

        }
        public SaveDataList() : base()
        {

        }
    }
}
