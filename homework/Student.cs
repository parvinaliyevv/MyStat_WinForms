using System;

namespace homework
{
    public class Student
    {
        private static int _id = 1;

        public int ID { get; set; } = _id++;
        public string Fullname { get; set; }

        public Student(string fullname) => Fullname = fullname;
    }
}
