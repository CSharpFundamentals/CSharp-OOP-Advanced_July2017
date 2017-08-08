public class Person
{
    public Person(long id, string username)
    {
        this.Id = id;
        this.Username = username;
    }

    public long Id { get; private set; }
    public string Username { get; private set; }

    public override bool Equals(object obj)
    {
        Person other = obj as Person;
        if (other == null)
        {
            return false;
        }

        if (this.Id == other.Id && this.Username == other.Username)
        {
            return true;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode() ^ this.Username.GetHashCode() ^ 23;
    }
}