﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Denna.Converters
{
    class IntToPendingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string x = "";
            int val = (int)value;
            if (val == 0)
            {
                x = "Nothing todo.";
            }
            else if (val == 1)
            {
                x = val + " task pending.";

            }
            else
            {
                x = val + " tasks pending.";

            }
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
