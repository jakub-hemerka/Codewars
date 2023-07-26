namespace EventAndDelegate;
public class Publisher
{
    public event EventHandler<PersonEventArgs>? ContactNotify;
    private readonly Dictionary<string, int> _contacts = new();

    public void CountMessages(List<string> peopleList)
    {
        foreach (string person in peopleList)
        {
            if (_contacts.ContainsKey(person))
            {
                _contacts[person] += 1;
            }
            else
            {
                _contacts.Add(person, 1);
            }

            if (_contacts[person] % 3 == 0)
            {
                OnContactNotify(person);
            }
        }
    }

    protected virtual void OnContactNotify(string name)
    {
        ContactNotify?.Invoke(this, new PersonEventArgs { Name = name });
    }
}