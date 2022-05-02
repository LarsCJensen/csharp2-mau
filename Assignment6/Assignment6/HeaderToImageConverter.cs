using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Assignment6
{
    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance =
            new HeaderToImageConverter();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if ((value as string).Contains(@"\"))
            {
                Uri uri = new Uri
                ("pack://application:,,,/Assets/disk.png");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
            else
            {
                Uri uri = new Uri("pack://application:,,,/Assets/folder.jpg");
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // HeaderToImageConverter
    // TODO REMOVE BELOW!!
    public class Account<T> : ICloneable
    {
        public int CompareTo(Account<T>? other)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
    public class Generic<T>
    {
        private T value;
        public void Test()
        {
            //T sum = value + 1;
        }
    }

    class GenericTest
    {
        public void Test<X>(X value)
        {
            Console.WriteLine(value.ToString());
        }
    }

    class GenericConstraints<T, U> where T : BankLoan
    {
        public void Test(T t, U u)
        {
            Console.WriteLine(t.ToString() + "\n" + u.ToString());
        }
    }

    
    class BankLoan
    {

        public override string ToString()
        {
            return "BankLoan object";
        }
    }

    interface IAccount
    {
        string Name { get; set; }
    }

    class GenericAccount<T>: IAccount
    {
        private T m_id;

        public T ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}