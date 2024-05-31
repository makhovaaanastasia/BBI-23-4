namespace ЛР_10_1
{
    public interface ITable
    {
        void AddMatch(Team team1, Team team2);
        void Sort(string criteria);
        void Sort(int dummy);
    }
}
