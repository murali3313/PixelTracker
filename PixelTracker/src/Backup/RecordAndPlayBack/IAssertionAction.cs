namespace RecordAndPlayBack
{
    public interface IAssertionAction
    {
        void Execute();
        void Save(int order, int scenarioID);
        void Load();
    }

    public enum TestType
    {
        Action,
        Assertion
    }
}