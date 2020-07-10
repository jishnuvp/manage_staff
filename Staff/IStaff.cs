using System;
using System.Collections.Generic;
using System.Text;

namespace Staff
{
    interface IStaff
    {
        public void AddStaff();
        public void ViewStaff(int index, int slNum = 0);
        public void UpdateStaff();
    }
}
