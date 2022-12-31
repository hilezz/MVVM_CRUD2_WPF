using System;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using studentMVVM.model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using studentMVVM.Commands;
using System.Windows;

namespace studentMVVM.viewmodel
{
    public class studentviewmodel : INotifyPropertyChanged

    {
        public studentviewmodel()
        {
            Student = new Student()
            {
                GenderMale = true,
                Course1 = true

            };

            Departments = new List<Department>();
            Departments.Add(new Department() { Departmentid = 1, DepartmentName = "CSE" });
            Departments.Add(new Department() { Departmentid = 2, DepartmentName = "ECE" });
            //Departments.Add(new Department() { Departmentid = 3, DepartmentName = "civil" });
            
        }


        private Student _student;
        public event PropertyChangedEventHandler PropertyChanged;
        //connecting ui to the model
        public Student Student
        {
            get { return _student; }
            set { _student = value; 
                NotifyPropertChanged("Student"); }
        }

        //creating list of the data
        private List<Department> _departments;
        public List<Department> Departments
        { 
            get { return _departments; }
            set
            {
                _departments = value; NotifyPropertChanged("Departments");
            }
        }

        private ObservableCollection<Student> _students;
        
        public ObservableCollection<Student> Students
        {
            get 
            {
                return _students;
            }
            set
            {
                _students = value; 
                NotifyPropertChanged("Students");
            }
        }

        //section for checkbox----------------------------------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------------------------------------
       
        private Relaycommand _submitcmd;
        public Relaycommand Submitcommand
        {
            get 
            { 
                if (_submitcmd == null)
                {
                       _submitcmd = new Relaycommand(SubmitExecute,CanSubmitExecute);
                }
                return _submitcmd; 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        private void SubmitExecute(Object parameter)
        {
            if (Students == null)
                Students = new ObservableCollection<Student>();

            Students.Add(new Student()
            {
               RegID = Student.RegID,
               Stname = Student.Stname,
               Gender = Student.GenderMale ? "Male" : "Female",
               Course = Student.Course1 ? "CS01" : "EC02",
               Dep = new Department() { Departmentid=Student.Dep.Departmentid,DepartmentName=Student.Dep.DepartmentName },
            });
        }
        private bool CanSubmitExecute(Object parameter)
        {
            if (Student !=null && string.IsNullOrEmpty(Student.RegID) || string.IsNullOrEmpty(Student.Stname))
            {

                return false;
            }
            else
            {
                return true;

            }
        }

        private void NotifyPropertChanged(string PropertName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertName));
            }
        }

    }
    
}
