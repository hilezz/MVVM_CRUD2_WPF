using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace studentMVVM.model
{
    public class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(Expression<Func<T>> property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(FindPropertyName(property)));
        }

        public static string FindPropertyName<T>(Expression<Func<T>> property)
        {
            var propertyInfo = (property.Body as MemberExpression).Member as System.Reflection.PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
            return propertyInfo.Name;
        }

    }
    public class Student : BaseNotify
    {
        
        private string regid;

        public string RegID
        {
            get { return regid; }
            set { regid = value; 
                OnPropertyChanged(()=>RegID); }
        }

        private string name;

        public string Stname
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged(()=>Stname); }
        }
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value;
                OnPropertyChanged(()=>Gender); }
        }

        private bool genderMale;
        public bool GenderMale
        {
            get { return genderMale; }
            set
            {
                genderMale = value;
                OnPropertyChanged(() => GenderMale);
                if (value)
                    GenderFemale = false;
            }
        }

        private bool genderfemale;
        public bool GenderFemale
        {
            get { return genderfemale; }
            set
            {
                genderfemale = value;
                OnPropertyChanged(() => GenderFemale);
                if (value)
                    GenderMale = false;
            }
        }


        private string course;

        public string Course
        {
            get { return course; }
            set { course = value;
                OnPropertyChanged(()=>Course); }
        }

        private bool course1;
        public bool Course1
        {
            get { return course1; }
            set
            {
                course1 = value;
                OnPropertyChanged(() => Course1);
                if (value)
                    Course2  = false;
            }
        }

        private bool course2;
        public bool Course2
        {
            get { return course2; }
            set
            {
                course2 = value;
                OnPropertyChanged(() => Course2);
                if (value)
                    Course1  = false;
            }
        }

        //private bool course3;
        //public bool Course3
        //{
        //    get { return course3; }
        //    set
        //    {
        //        course3 = value;
        //        OnPropertyChanged(() => Course3);
        //        if (value)
                
        //            Course2 = Course1 = false;
                    
               

        //    }
        //}



        private Department dep;
        public Department Dep
        {
            get { return dep; }
            set
            {
                dep = value;
                OnPropertyChanged(() => Dep);
            }
        }

    }
    public class Department : BaseNotify
    {
        private int departmentid;
        public int Departmentid
        {
            get { return departmentid; }
            set { departmentid = value;
                OnPropertyChanged(() => Departmentid);

            }
        }

        private string departmentname;
        public string DepartmentName
        {
            get { return departmentname; }
            set
            {
                departmentname = value;
                OnPropertyChanged(() => DepartmentName);
            }
        }
    }
}
