// cau 2
class Student
{
    public string Name { get; set; }
    public Scores Score { get; set; }

    public double GetAverageScore()
    {
        return (Score.Math + Score.Physic + Score.Chemistry) / 3.0;
    }
}

class Scores
{
    public int Math { get; set; }
    public int Physic { get; set; }
    public int Chemistry { get; set; }
}

class Program
{
    static void Main()
    {   // a) Khoi tao mang voi du lieu ngau nhien
        Student[] students = new Student[]
        {
            new Student { Name = "Tu Thai Phong", Score = new Scores { Math = 7, Physic = 8, Chemistry = 9 }},
            new Student { Name = "Ngo Thuy Linh", Score = new Scores { Math = 10, Physic = 7, Chemistry = 8 }},
            new Student { Name = "Tu Tue Minh", Score = new Scores { Math = 6, Physic = 8, Chemistry = 9 }},
        };

        // b) Sap xep theo diem trung binh giam dan, neu bang diem, sap xep theo ten tang dan
        for (int i = 0; i < students.Length - 1; i++)
        {
            for (int j = i + 1; j < students.Length; j++)
            {
                double averageScoreI = students[i].GetAverageScore();
                double averageScoreJ = students[j].GetAverageScore();

                if (averageScoreI < averageScoreJ ||
                    (averageScoreI == averageScoreJ && string.Compare(students[i].Name, students[j].Name, StringComparison.Ordinal) > 0))
                {
                    // Swap
                    Student temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }
        }
        // Tim hs co diem tb la 8
        Student studentWithAverage8 = Array.Find(students, student => student.GetAverageScore() == 8);

        // In hs co diem trung binh la 8 (neu co)
        if (studentWithAverage8 != null)
        {
            Console.WriteLine($"Hs co diem tb la 8: {studentWithAverage8.Name}");
        }
        else
        {
            Console.WriteLine("Khong co hs nao co diem tb la 8.");
        }
    }
}
