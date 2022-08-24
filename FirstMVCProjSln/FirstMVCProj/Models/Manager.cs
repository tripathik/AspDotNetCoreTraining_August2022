namespace FirstMVCProj.Models
{
    public class Manager
    {
        public int Manager_Id { get; set; }
        public string Manager_Name { get; set; }
        public decimal Salary { get; set; }

        public static List<Manager> managers = new List<Manager>();
        public static Manager m1 = new Manager();
        public static Manager m2 = new Manager();

        public static List<Manager> GetManagers()
        {
            m1.Manager_Id = 100;
            m1.Manager_Name = "Krishna Tripathi";
            m1.Salary = 200000;

            m2.Manager_Id = 101;
            m2.Manager_Name = "Tripti Chaubey";
            m2.Salary = 150000;

            managers.Add(m1);
            managers.Add(m2);
            return managers;
        }

        public static void AddManagers(Manager manager)
        {
            managers.Add(manager);
        }

        public static void EditManager(Manager manager)
        {
            int id = manager.Manager_Id;
            Manager oldobj = managers.Where(x => x.Manager_Id == id).FirstOrDefault();
            managers.Remove(oldobj);
            managers.Add(manager);
        }

        public static void DeleteManager(int id)
        {
            Manager oldobj = managers.Where(x => x.Manager_Id == id).FirstOrDefault();
            managers.Remove(oldobj);
        }
    }
}
