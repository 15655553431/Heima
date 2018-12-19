using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringNetDemo
{
    public interface IUserInfoDal
    {
        void show();
        string Name { get; set; }
    }
}
