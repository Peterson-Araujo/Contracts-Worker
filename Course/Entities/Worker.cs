using System.Collections.Generic;
using Course.Entities.Enums;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // como é 1 para muitos, tem que ser uma lista

        public Worker()
        {

        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //O construtor normalmente não recebe a lista
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {
                    sum += contract.totalValue();
                }
            }
            return sum;
        }
    }
}
