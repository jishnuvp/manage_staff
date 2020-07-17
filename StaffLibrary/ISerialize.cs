using System;
using System.Collections.Generic;
using System.Text;

namespace StaffLibrary
{
    interface ISerialize
    {
        void Serialize(List<Staff> list);
        bool DeSerialize(List<Staff> list);
    }
}
