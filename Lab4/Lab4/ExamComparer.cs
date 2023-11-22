namespace Lab4
{
    internal class ExamComparer : IComparer<Exam>
    {
        public int Compare(Exam x, Exam y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}