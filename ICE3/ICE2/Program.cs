namespace ICE2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Surnames= new string[] {"Smith","Lerato","Carol","Kabelo","Jones","James","Bongani","Keith"};
            List<Employee> empList= new List<Employee>();
            Employee employee = new Employee();

            for (int i = 0; i < Surnames.Length; i++)
            {
                employee.Surname= Surnames[i];
            }
            #region Unsorted List
            empDepartment(empList,Surnames);
            Console.WriteLine("Unsorted List");
            foreach (Employee emp in empList)
            {
                Console.Write("\n");
                Console.WriteLine($"Department ID: {emp.departmentID} \t Surname: {emp.Surname}");
            }
            Console.WriteLine();
            #endregion

            #region Sorted List
            sortEmpList(empList);
            Console.WriteLine("Sorted List");
            foreach (Employee emp in empList)
            {
                Console.Write("\n");
                Console.WriteLine($"Department ID: {emp.departmentID} \t Surname: {emp.Surname}");
            }
            #endregion
        }

        #region List population
        /// <summary>
        /// Method to populkate the empList as well as a random department ID to each surname
        /// </summary>
        /// <param name="empList"></param>
        /// <param name="surnames"></param>
        private static void empDepartment(List<Employee> empList, string[] surnames)
        {
            Random rnd = new Random();
            bool[] selected = new bool[surnames.Length];
            int remainingEmp = surnames.Length;

            while (remainingEmp > 0)
            {
                int rndE = rnd.Next(0, surnames.Length);

                if (!selected[rndE])
                {
                    int rndD = rnd.Next(1, 6);
                    string emp = surnames[rndE];
                    empList.Add(new Employee(surnames[rndE], rndD));
                    selected[rndE] = true;
                    remainingEmp--;
                }
            }
        }
        #endregion

        #region Sorting List
        private static void sortEmpList(List<Employee> empList)
        {
            for (int i = 0; i < empList.Count - 1; i++)
            {
                for (int j = i + 1; j < empList.Count; j++)
                {
                    bool departmentComparison = empList[i].departmentID > empList[j].departmentID;

                    if (departmentComparison || (empList[i].departmentID == empList[j].departmentID && string.Compare(empList[i].Surname, empList[j].Surname) > 0))
                    {
                        Employee temp = empList[i];
                        empList[i] = empList[j];
                        empList[j] = temp;
                    }
                }
            }
        }
        #endregion


    }
}